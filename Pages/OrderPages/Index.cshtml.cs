using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderPages
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _service;

        public IList<OrderViewModel> Orders { get; set; }


        public IndexModel(IOrderService service)
        {
            _service = service;
        }


        public async Task OnGetAsync()
        {
            Orders = await _service.GetAllAsync();

            if (Orders == null)
            {
                BadRequest();
            }

            //ViewData["Orders"] = JsonSerializer.Serialize(Orders);

            ViewData["OrderList"] = GetAllOrders();
        }

        public JsonResult GetAllOrders()
        {
            return new JsonResult(Orders.ToList());
        }
    }
}