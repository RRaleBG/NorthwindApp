using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using NorthwindApp.Models;
using NorthwindApp.Models.Views;
using System.Globalization;
using System.Text.Json;


namespace NorthwindApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindDBContext _dbContext;   
        

        public IndexModel( NorthwindDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductSalesFor1997> Sales97 { get; set; }
        public List<ProductSalesFor1996> Sales96 { get; set; }
        public List<ProductSalesFor1998> Sales98 { get; set; }

        public List<CategorySalesFor1997> CategorySales97 { get; set; }

        public  List<object> Lista { get; set; }
        public decimal categorySales { get; set; }

        public void OnGet()
        {
            var category = (decimal)_dbContext.CategorySalesFor1997.Sum(c => c.CategorySales);
            categorySales = Math.Ceiling(category);

            // TotalSum
            var TotalSum = _dbContext.CategorySalesFor1997.Sum(e => e.CategorySales);
            CultureInfo culture1 = CultureInfo.CreateSpecificCulture("en-US");
            culture1.NumberFormat.NumberDecimalDigits = 2;
            ViewData["Total"] = TotalSum.Value.ToString("C0");


            CategorySales97 = _dbContext.CategorySalesFor1997.ToList();
            ViewData["CategorySales97"] = JsonSerializer.Serialize(CategorySales97);
            

            Sales96 = _dbContext.ProductSalesFor1996.ToList();            
            ViewData["Sales96"] = JsonSerializer.Serialize(Sales96);

            Sales97 = _dbContext.ProductSalesFor1997.ToList();
            ViewData["Sales97"] = JsonSerializer.Serialize(Sales97);

            Sales98 = _dbContext.ProductSalesFor1998.ToList();
            ViewData["Sales98"] = JsonSerializer.Serialize(Sales98);

            Lista = new List<object>();

            foreach (var item in Sales96.ToString())
            {
                Lista.Add(item);
            }

            foreach (var item in Sales97.ToString())
            {
                Lista.Add(item);
            }

            foreach (var item in Sales98)
            {
                Lista.Add(item);
            }
            

            ViewData["Lista"] = JsonSerializer.Serialize(Lista);
            
        }


        public JsonResult JsonData()
        {
            var Sales = new List<object>();
            Sales.Add(Sales96);
            Sales.Add(Sales97);
            Sales.Add(Sales98);

            ViewData["Sales"] = JsonSerializer.Serialize(Sales);
            
            return new JsonResult(Sales);
        }


        public List<Shipper> Shipper { get; set; }


        public JsonResult GetTotalShippers()
        {
            Shipper = _dbContext.Shippers.ToList();
                                  
            return new JsonResult(Shipper);
        }
    }
}
