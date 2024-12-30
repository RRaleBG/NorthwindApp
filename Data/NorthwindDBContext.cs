using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using NorthwindApp.Models;
using NorthwindApp.Models.Views;
using System.Diagnostics;

namespace Northwind.Data
{

    public class NorthwindDBContext : DbContext
    {
        public NorthwindDBContext(DbContextOptions<NorthwindDBContext> options)
            : base(options)
        {
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


        public DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; }
        public DbSet<CategorySalesFor1997> CategorySalesFor1997 { get; set; }
        public DbSet<CurrentProductList> CurrentProductList { get; set; }
        public DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCity { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderDetailsExtended> OrderDetailsExtended { get; set; }
        public DbSet<OrderSubtotal> OrderSubtotals { get; set; }
        public DbSet<OrdersQry> OrdersQry { get; set; }
        public DbSet<ProductSalesFor1996> ProductSalesFor1996 { get; set; }
        public DbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; }
        public DbSet<ProductSalesFor1998> ProductSalesFor1998 { get; set; }
        public DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrice { get; set; }
        public DbSet<ProductsByCategory> ProductsByCategory { get; set; }
        public DbSet<QuarterlyOrder> QuarterlyOrders { get; set; }
        public DbSet<SalesByCategory> SalesByCategory { get; set; }
        public DbSet<SalesTotalsByAmount> SalesTotalsByAmount { get; set; }
        public DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarter { get; set; }
        public DbSet<SummaryOfSalesByYear> SummaryOfSalesByYear { get; set; }
        public DbSet<TotalSales> TotalSales { get; set; }
        public DbSet<MostSoldProductForEachCountry> MostSoldProductForEachCountry { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
            {
                entity.HasNoKey().ToView("Alphabetical list of products");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<CategorySalesFor1997>(entity =>
            {
                entity.HasNoKey().ToView("Category Sales for 1997");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.CategorySales).HasColumnType("money");
            });

            modelBuilder.Entity<CurrentProductList>(entity =>
            {
                entity.HasNoKey().ToView("Current Product List");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
            {
                entity.HasNoKey().ToView("Customer and Suppliers by City");

                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ContactName).HasMaxLength(30);
                entity.Property(e => e.Relationship)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasNoKey().ToView("Invoices");

                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");
                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ExtendedPrice).HasColumnType("money");
                entity.Property(e => e.Freight).HasColumnType("money");
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.Region).HasMaxLength(15);
                entity.Property(e => e.RequiredDate).HasColumnType("datetime");
                entity.Property(e => e.Salesperson)
                    .IsRequired()
                    .HasMaxLength(31);
                entity.Property(e => e.ShipAddress).HasMaxLength(60);
                entity.Property(e => e.ShipCity).HasMaxLength(15);
                entity.Property(e => e.ShipCountry).HasMaxLength(15);
                entity.Property(e => e.ShipName).HasMaxLength(40);
                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
                entity.Property(e => e.ShipRegion).HasMaxLength(15);
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
                entity.Property(e => e.ShipperName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<OrderDetailsExtended>(entity =>
            {
                entity.HasNoKey().ToView("OrderDetails Extended");

                entity.Property(e => e.ExtendedPrice).HasColumnType("money");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<OrderSubtotal>(entity =>
            {
                entity.HasNoKey().ToView("Order Subtotals");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<OrdersQry>(entity =>
            {
                entity.HasNoKey().ToView("Orders Qry");

                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.Freight).HasColumnType("money");
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.Region).HasMaxLength(15);
                entity.Property(e => e.RequiredDate).HasColumnType("datetime");
                entity.Property(e => e.ShipAddress).HasMaxLength(60);
                entity.Property(e => e.ShipCity).HasMaxLength(15);
                entity.Property(e => e.ShipCountry).HasMaxLength(15);
                entity.Property(e => e.ShipName).HasMaxLength(40);
                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
                entity.Property(e => e.ShipRegion).HasMaxLength(15);
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            });


            modelBuilder.Entity<ProductSalesFor1996>(entity =>
            {
                entity.HasNoKey().ToView("Product Sales for 1996");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ProductSales).HasColumnType("money");
            });

            modelBuilder.Entity<ProductSalesFor1997>(entity =>
            {
                entity.HasNoKey().ToView("Product Sales for 1997");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ProductSales).HasColumnType("money");
            });

            modelBuilder.Entity<ProductSalesFor1998>(entity =>
            {
                entity.HasNoKey().ToView("Product Sales for 1998");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ProductSales).HasColumnType("money");
            });


            modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
            {
                entity.HasNoKey().ToView("Products Above Average Price");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<ProductsByCategory>(entity =>
            {
                entity.HasNoKey().ToView("Products by Category");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            });

            modelBuilder.Entity<QuarterlyOrder>(entity =>
            {
                entity.HasNoKey().ToView("Quarterly Orders");

                entity.Property(e => e.City)
                    .HasMaxLength(15);
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(40);
                entity.Property(e => e.Country)
                    .HasMaxLength(15);
                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");
            });

            modelBuilder.Entity<SalesByCategory>(entity =>
            {
                entity.HasNoKey().ToView("Sales by Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ProductSales).HasColumnType("money");
            });

            modelBuilder.Entity<SalesTotalsByAmount>(entity =>
            {
                entity.HasNoKey().ToView("Sales Totals by Amount");

                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(40);
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.SaleAmount).HasColumnType("money");
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
            {
                entity.HasNoKey().ToView("Summary of Sales by Quarter");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
            {
                entity.HasNoKey().ToView("Summary of Sales by Year");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
                entity.Property(e => e.Subtotal).HasColumnType("money");
            });


            modelBuilder.Entity<TotalSales>(entity =>
            {
                entity.HasNoKey().ToView("Total Sales");

                entity.Property(x => x.ProductId)
                .HasColumnName("ProductID")
                .HasPrecision(10, 0);

                entity
                    .Property(x => x.ProductName)
                    .HasColumnName("ProductName")
                    .IsUnicode(true);
                entity
                    .Property(x => x.TotalSales1)
                    .HasColumnName("TotalSales");
            });

            modelBuilder.Entity<MostSoldProductForEachCountry>(entity =>
            {
                entity.HasNoKey().ToView("Most sold Product for each country");

                entity
                .Property(x => x.CountryRank)
                .HasColumnName("countryRank")
                .HasPrecision(19, 0);

                entity
                    .Property(x => x.Country)
                    .HasColumnName("Country")
                    .IsUnicode(true);

                entity
                    .Property(x => x.ProductName)
                    .HasColumnName("ProductName")
                    .IsUnicode(true);

                entity
                    .Property(x => x.Quantity)
                    .HasColumnName("Quantity")
                    .HasPrecision(10, 0);
            });


        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cnn = "Data Source=DESKTOP;Initial Catalog=NORTHWND;Integrated Security=true;TrustServerCertificate=Yes;";
            //enable sensitive data logging when debugging
            if (Debugger.IsAttached)
            {
                optionsBuilder.UseSqlServer(cnn)
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextToFileLogger()
                .Log, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);
            }
            else
            {
                optionsBuilder.UseSqlServer(cnn).LogTo(new DbContextToFileLogger().Log, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);
            }
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
