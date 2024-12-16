using Microsoft.AspNetCore.Mvc;
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
        
        private readonly NorthwindDBContext _dbContext;

        public IndexModel(IOrderDetailsService context, NorthwindDBContext dbContext)
        {
            _context = context;
            _dbContext = dbContext;
        }

        [BindProperty(SupportsGet = true)]
        public List<OrderDetailsViewModel> OrderDetail { get; set; }

        public async void OnGetAsync()
        {
            OrderDetail = await _context.GetAllAsync();

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



            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(OrderDetail);

            ViewData["OrderDetail"] = json;
        }
    }
}
