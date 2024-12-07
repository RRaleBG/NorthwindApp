using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderPages
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _service;
        public IList<OrderViewModel> Orders { get;set; } = default!;

        public IndexModel(IOrderService service)
        {
            _service = service;
        }


        public async Task OnGetAsync()
        {
            Orders = await _service.GetAllAsync();

            if(Orders == null)
            {
                BadRequest();
            }
                      
        
        }
    }
}
