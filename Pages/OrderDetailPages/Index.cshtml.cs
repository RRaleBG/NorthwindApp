using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Northwind.Data;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderDetailPages
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailsService _context;
        private readonly IOrderService _orderService;
        private readonly NorthwindDBContext _dbContext;

        public IndexModel(IOrderDetailsService context, NorthwindDBContext dbContext)
        {
            _context = context;
            _dbContext = dbContext;
        }


        public IQueryable<OrderDetailsViewModel> OrderDetail { get; set; } = default!;

        public List<LayoutData> SplineChartData { get; set; }

        public class LayoutData
        {
            public string? Period;
            public double? OnlinePercentage;
            public double? RetailPercentage;
        }

        public async Task OnGetAsync()
        {

            OrderDetail = _context.GetAllAsync().Result.AsQueryable();

            var queryc = from order in _dbContext.Orders
                         join customer in _dbContext.Customers on order.CustomerID equals customer.CustomerID
                         join employee in _dbContext.Employees on order.EmployeeID equals employee.EmployeeID
                         where order.OrderDate >= Convert.ToDateTime("1996.12.12")
                         orderby order.OrderDate ascending                        
                         select new
                         {
                             Period = order.OrderDate,
                             freight = order.Freight,  
                             company = order.Customer.CompanyName,
                             employee = employee.FirstName,
                         };



            SplineChartData = new List<LayoutData>
            {
                    new LayoutData{ Period = "Jan", OnlinePercentage = 3600, RetailPercentage = 6400 },
                    new LayoutData{ Period = "Feb", OnlinePercentage = 6200, RetailPercentage = 5300 },
                    new LayoutData{ Period = "Mar", OnlinePercentage = 8100, RetailPercentage = 4900 },
                    new LayoutData{ Period = "Apr", OnlinePercentage = 5900, RetailPercentage = 5300 },
                    new LayoutData{ Period = "May", OnlinePercentage = 8900, RetailPercentage = 4200 },
                    new LayoutData{ Period = "Jun", OnlinePercentage = 7200, RetailPercentage = 6500 },
                    new LayoutData{ Period = "Jul", OnlinePercentage = 4300, RetailPercentage = 7900 },
                    new LayoutData{ Period = "Aug", OnlinePercentage = 4600, RetailPercentage = 3800 },
                    new LayoutData{ Period = "Sep", OnlinePercentage = 5500, RetailPercentage = 6800 },
                    new LayoutData{ Period = "Oct", OnlinePercentage = 6350, RetailPercentage = 3400 },
                    new LayoutData{ Period = "Nov", OnlinePercentage = 5700, RetailPercentage = 6400 },
                    new LayoutData{ Period = "Dec", OnlinePercentage = 8000, RetailPercentage = 6800 }
            };

            ViewData["OrderDetail"] = SplineChartData.ToList();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(OrderDetail);

            //ViewData["OrderDetail"] = json;
        }
    }
}
