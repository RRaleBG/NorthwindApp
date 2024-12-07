using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Northwind.Data;
using NorthwindApp.Pages;
using NorthwindApp.Repository;
using NorthwindApp.Repository.RepositoryViewModels;
using System.Text.Json.Serialization;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<NorthwindDBContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext"))
                         //.EnableSensitiveDataLogging()
                         //.LogTo(new DbContextToFileLogger().Log, new[]
                         //{
                         //    DbLoggerCategory.Database.Command.Name
                         //},
                         //LogLevel.Information)
        );


        builder.Services.AddControllers().AddJsonOptions(x => 
                     x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF1cXGdCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXZfeXVdRGhfUUV0X0c=");
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2UlhhQlVMfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTX5adEZiX3pfc3JUTmlb");

        builder.Services.AddScoped<ICategoryService, CategoryRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerRepository>();
        builder.Services.AddScoped<IOrderDetailsService, OrderDetailsRepository>();
        builder.Services.AddScoped<IOrderService, OrderRepository>();
        builder.Services.AddScoped<IProductService, ProductRepository>();        
        builder.Services.AddScoped<ISupplierService, SupplierRepository>();

        builder.Services.AddScoped<IBankDataRepository, BankDataRepository>();



        var app = builder.Build();

        // remove comments if database not exist to create database
        using (var service = app.Services.CreateScope())
        {
            try
            {
                var ctx = service.ServiceProvider.GetRequiredService<NorthwindDBContext>();

                ctx.GetInfrastructure().GetRequiredService<IMigrator>();
                // equivalent Update-Database -TargetMigration automatically update the database after a model changes
                if(ctx.Database.EnsureCreated() != true)
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
                var errorLog = service.ServiceProvider.GetRequiredService <ILogger<Program>> ();
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
        
        app.Run();
    }
}



