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

        [BindProperty(SupportsGet = true)]
        public List<OrderDetailsViewModel> OrderDetail { get; set; }

        public IndexModel(IOrderDetailsService context)
        {
            _context = context;
        }

        public async void OnGetAsync()
        {
            OrderDetail = await _context.GetAllOrdDetailsAsync();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(OrderDetail);

            ViewData["OrderDetail"] = json;
        }
    }
}
