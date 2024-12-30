using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Northwind.Data;
using NorthwindApp.Repository;
using NorthwindApp.Repository.RepositoryViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<NorthwindDBContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));


        builder.Services.AddControllers().AddJsonOptions(x =>
                     x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        //{
        //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //};

        // Register JsonSerializerOptions
        builder.Services.AddSingleton(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddScoped<ICategoryService, CategoryRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerRepository>();
        builder.Services.AddScoped<IOrderDetailsService, OrderDetailsRepository>();
        builder.Services.AddScoped<IOrderService, OrderRepository>();
        builder.Services.AddScoped<IProductService, ProductRepository>();
        builder.Services.AddScoped<ISupplierService, SupplierRepository>();


        var app = builder.Build();

        // remove comments if database not exist to create database
        using (var service = app.Services.CreateScope())
        {
            try
            {
                var ctx = service.ServiceProvider.GetRequiredService<NorthwindDBContext>();

                ctx.GetInfrastructure().GetRequiredService<IMigrator>();
                // equivalent Update-Database -TargetMigration automatically update the database after a model changes
                if (ctx.Database.EnsureCreated() != true)
                {
                    bool created = ctx.Database.EnsureCreated() ? false : ctx.Database.GetAppliedMigrations().Any();

                    if (created)
                    {
                        ctx.Database.GetAppliedMigrations();
                        ctx.Database.Migrate();
                    }
                }
            }
            catch (Exception ex)
            {
                var errorLog = service.ServiceProvider.GetRequiredService<ILogger<Program>>();
                errorLog.LogError(ex, "An error occurred creating");
            }
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        app.MapStaticAssets();
        app.Run();
    }
}



