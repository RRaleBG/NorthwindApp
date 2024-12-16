using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using NorthwindApp.Models;
using NorthwindApp.Models.Views;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;
using NuGet.Protocol;
using System.Text.Json;


namespace NorthwindApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindDBContext _dbContext;
        //private readonly IBankDataRepository _bankDataRepository;
        

        public IndexModel( NorthwindDBContext dbContext, IBankDataRepository bankDataRepository)
        {
            _dbContext = dbContext;
            //_bankDataRepository = bankDataRepository;
        }

        public List<ProductSalesFor1997> Sales97 { get; set; }
        public List<ProductSalesFor1996> Sales96 { get; set; }
        public List<ProductSalesFor1998> Sales98 { get; set; }

        public  List<object> Lista { get; set; }

        public void OnGet()
        {

            Sales96 = _dbContext.ProductSalesFor1996.Distinct().ToList();            
            ViewData["Sales96"] = JsonSerializer.Serialize(Sales96);

            Sales97 = _dbContext.ProductSalesFor1997.ToList();
            ViewData["Sales97"] = JsonSerializer.Serialize(Sales97);

            Sales98 = _dbContext.ProductSalesFor1998.ToList();
            ViewData["Sales98"] = JsonSerializer.Serialize(Sales98);

            Lista = new List<object>();

            foreach (var item in ViewData["Sales96"].ToString())
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
          









            //var bankData = _bankDataRepository.GetAllBankData();
            //ViewData["allBankData"] = JsonSerializer.Serialize(bankData);

            //var shipper = _dbContext.Shippers.ToList();  
            //ViewData["Shipper"] = JsonSerializer.Serialize(shipper.ToList());

            //ViewData["GetTotalShippers"] = JsonSerializer.Serialize(GetTotalShippers());

            // PRVI CHART
            //List<ChartData> prvi = new List<ChartData>
            //{
            //    new ChartData { x= "USA", yValue= 46, yValue1=56 },
            //    new ChartData { x= "GBR", yValue= 27, yValue1=17 },
            //    new ChartData { x= "CHN", yValue= 26, yValue1=36 },
            //    new ChartData { x= "UK",  yValue= 56, yValue1=16 },
            //    new ChartData { x= "AUS", yValue= 12, yValue1=46 },
            //    new ChartData { x= "IND", yValue= 26, yValue1=16 },
            //    new ChartData { x= "DEN", yValue= 26, yValue1=12 },
            //    new ChartData { x= "MEX", yValue= 34, yValue1=32},
            //};            
            //ViewData["prvi"] = prvi;

            //// DRUGI CHART
            //List<PieChartData> pieChartData = new List<PieChartData>
            //{
            //    new PieChartData { X = "Jan", Y = 3, Z= 4 },
            //    new PieChartData { X = "Feb", Y = 3.5, Z= 1 },
            //    new PieChartData { X = "Mar", Y = 7, Z= 8 },
            //    new PieChartData { X = "Apr", Y = 13.5, Z= 7 },
            //    new PieChartData { X = "May", Y = 19, Z= 5 },
            //    new PieChartData { X = "Jun", Y = 23.5, Z= 9 },
            //    new PieChartData { X = "Jul", Y = 26, Z= 7 },
            //    new PieChartData { X = "Aug", Y = 25, Z= 3 },
            //    new PieChartData { X = "Sep", Y = 21, Z= 16 },
            //    new PieChartData { X = "Oct", Y = 15, Z= 22 }
            //};
            //ViewData["pieChartData"] = pieChartData;
        }
   

        public class PieChartData
        {
            public string X;
            public double Y;
            public int Z;
        }

        public class ChartData
        {
            public string x;
            public double yValue;
            public double yValue1;
        }      

        public class PolarData
        {
            public double x;
            public double y;
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
