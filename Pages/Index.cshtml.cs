using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using NorthwindApp.Models.Views;
using NorthwindApp.ViewModel;
using System.Globalization;
using System.Text.Json;


namespace NorthwindApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindDBContext _dbContext;
        private readonly JsonSerializerOptions _jsonOptions;

        public IndexModel(NorthwindDBContext dbContext, JsonSerializerOptions jsonOptions)
        {
            _dbContext = dbContext;
            _jsonOptions = jsonOptions;
        }

        public List<ProductSalesFor1997> Sales97 { get; set; }
        public List<ProductSalesFor1996> Sales96 { get; set; }
        public List<ProductSalesFor1998> Sales98 { get; set; }

        public List<CategorySalesFor1997> CategorySales97 { get; set; }
        public List<CategorySalesFor1997> CategorySales96 { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public List<object> Lista { get; set; }
        public decimal categorySales { get; set; }
        public int Shipper { get; set; }

        public async Task OnGetAsync()
        {
            // doughnut
            CategorySales97 = await _dbContext.CategorySalesFor1997.ToListAsync();
            ViewData["CategorySales97"] = JsonSerializer.Serialize(CategorySales97);

            CategorySales96 = await _dbContext.CategorySalesFor1997.ToListAsync();
            ViewData["CategorySales96"] = JsonSerializer.Serialize(CategorySales96);

            // MultiLine chart
            Sales96 = await _dbContext.ProductSalesFor1996.Distinct().ToListAsync();
            ViewData["Sales96"] = JsonSerializer.Serialize(Sales96);

            Sales97 = await _dbContext.ProductSalesFor1997.Distinct().ToListAsync();
            ViewData["Sales97"] = JsonSerializer.Serialize(Sales97);

            Sales98 = await _dbContext.ProductSalesFor1998.Distinct().ToListAsync();
            ViewData["Sales98"] = JsonSerializer.Serialize(Sales98);

            var totalSales96Value = Sales96.Sum(c => c.ProductSales).Value;
            var totalSales97Value = Sales97.Sum(c => c.ProductSales).Value;
            var totalSales98Value = Sales98.Sum(c => c.ProductSales).Value;
            var totalValue = totalSales96Value + totalSales97Value + totalSales98Value;

            var total = totalValue.ToString("C0", CultureInfo.CurrentCulture);
            ViewData["ProductSalesInTotal"] = total;

            Shipper = await _dbContext.Shippers.SumAsync(m => m.ShipperID);
            ViewData["Shipper"] = JsonSerializer.Serialize(Shipper);

            Employees = await _dbContext.Employees.Select(e => new EmployeeViewModel
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
                Photo = e.Photo,
                City = e.City,
            }).Take(5).ToListAsync();

            ViewData["Employees"] = JsonSerializer.Serialize(Employees);

        }


        public async Task<JsonResult> GetTotalShippersAsync()
        {
            Shipper = await _dbContext.Shippers.SumAsync(m => m.ShipperID);
            return new JsonResult(Shipper);
        }
    }
}
