using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using NorthwindApp.Models;
using System.Diagnostics;

namespace Northwind.Data
{
    public class NorthwindDBContext : DbContext
    {
        private readonly ILogger<NorthwindDBContext> _logger;
        public NorthwindDBContext(DbContextOptions<NorthwindDBContext> options, ILogger<NorthwindDBContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cnn = "Data Source=DESKTOP;Initial Catalog=NORTHWND;Integrated Security=true;TrustServerCertificate=Yes;";

            // enable sensitive data logging when debugging
            //if (Debugger.IsAttached)
            //{
            //    optionsBuilder.UseSqlServer(cnn)
            //    .EnableSensitiveDataLogging()
            //    .LogTo(new DbContextToFileLogger()
            //    .Log, new[]
            //    {
            //        DbLoggerCategory.Database.Command.Name
            //    },
            //    LogLevel.Information);
            //}
            //else
            //{
            //    optionsBuilder.UseSqlServer(cnn).LogTo(new DbContextToFileLogger().Log, new[]
            //    {
            //        DbLoggerCategory.Database.Command.Name
            //    },
            //    LogLevel.Information);
            //}
        }

        //public async Task SeedAsync()
        //{
        //    try
        //    {
        //        AddData();

        //        if (ChangeTracker.HasChanges())
        //        {
        //            await SaveChangesAsync();
        //            _logger.LogInformation("Data seed`s success!");
        //        }
        //    }
        //    catch
        //    {

        //        _logger.LogInformation("Data seeds problem!");
        //    }
        //}

        //public void Seed()
        //{
        //    try
        //    {
        //        AddData();

        //        if (ChangeTracker.HasChanges())
        //        {
        //            SaveChanges();
        //            _logger.LogInformation("Data seed`s success!");
        //        }
        //    }
        //    catch
        //    {
        //        _logger.LogInformation("Data seeds problem!");
        //    }
        //}

        //public void AddData()
        //{
        //    if (!Customers.Any())
        //    {
        //        Customers.AddRange(Customers);
        //        _logger.LogInformation("Data seeds problem!");
        //    }

        //    if (!Categories.Any())
        //    {
        //        Categories.AddRange(Categories);
        //    }

        //    if (!Employees.Any())
        //    {
        //        Employees.AddRange(Employees);
        //        _logger.LogInformation("Data seeds problem!");
        //    }

        //    if (!Orders.Any())
        //    {
        //        Orders.AddRange(Orders);
        //    }

        //    if (!OrderDetails.Any())
        //    {
        //        OrderDetails.AddRange(OrderDetails);
        //    }

        //    if (!Products.Any())
        //    {
        //        Products.AddRange(Products);
        //    }

        //    if (!Regions.Any())
        //    {
        //        Regions.AddRange(Regions);
        //    }

        //    if (!Territories.Any())
        //    {
        //        Territories.AddRange(Territories);
        //    }

        //    if (!Suppliers.Any())
        //    {
        //        Suppliers.AddRange(Suppliers);
        //    }
        //}

    }
}
