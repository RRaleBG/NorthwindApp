using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using NorthwindApp.Models;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;
using System.Text.Json;

namespace NorthwindApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NorthwindDBContext _dbContext;
        private readonly IBankDataRepository _bankDataRepository;


        public IndexModel(ILogger<IndexModel> logger, NorthwindDBContext dbContext, IBankDataRepository bankDataRepository)
        {
            _logger = logger;
            _dbContext = dbContext;
            _bankDataRepository = bankDataRepository;
        }



        public List<OrderViewModel> Total { get; set; }
        public List<OrderDetailsViewModel> Detail { get; set; }
        public List<SupplierViewModel> Label { get; set; } = default!;


        public void OnGet()
        {
            var bankData = _bankDataRepository.GetAllBankData();
            ViewData["allBankData"] = JsonSerializer.Serialize(bankData);

            // PRVI CHART
            List<ChartData> prvi = new List<ChartData>
            {
                new ChartData { x= "USA", yValue= 46, yValue1=56 },
                new ChartData { x= "GBR", yValue= 27, yValue1=17 },
                new ChartData { x= "CHN", yValue= 26, yValue1=36 },
                new ChartData { x= "UK",  yValue= 56, yValue1=16 },
                new ChartData { x= "AUS", yValue= 12, yValue1=46 },
                new ChartData { x= "IND", yValue= 26, yValue1=16 },
                new ChartData { x= "DEN", yValue= 26, yValue1=12 },
                new ChartData { x= "MEX", yValue= 34, yValue1=32},
            };            
            ViewData["prvi"] = prvi;

            // DRUGI CHART
            List<PieChartData> pieChartData = new List<PieChartData>
            {
                new PieChartData { X = "Jan", Y = 3, Z= 4 },
                new PieChartData { X = "Feb", Y = 3.5, Z= 1 },
                new PieChartData { X = "Mar", Y = 7, Z= 8 },
                new PieChartData { X = "Apr", Y = 13.5, Z= 7 },
                new PieChartData { X = "May", Y = 19, Z= 5 },
                new PieChartData { X = "Jun", Y = 23.5, Z= 9 },
                new PieChartData { X = "Jul", Y = 26, Z= 7 },
                new PieChartData { X = "Aug", Y = 25, Z= 3 },
                new PieChartData { X = "Sep", Y = 21, Z= 16 },
                new PieChartData { X = "Oct", Y = 15, Z= 22 }
            };
            ViewData["pieChartData"] = pieChartData;
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





        public List<Shipper> Shippers { get; set; }


        public async Task<JsonResult> GetTotalShippers()
        {
            Shippers = await _dbContext.Shippers.ToListAsync();

            var total = new List<Shipper>();
                      
            foreach (var item in total)
            {
                total.Add(item);

                ViewData["total"] = total;

                return new JsonResult(total);

            }
            return new JsonResult(Shippers);
        }
    }
}
