using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderDetailPages
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public DetailsModel(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [BindProperty]
        public OrderDetailsViewModel OrderViewDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id, int id2)
        {
            OrderViewDetail = await _orderDetailsService.GetByIdAsync(id, id2);

            return Page();
        }
    }
}
