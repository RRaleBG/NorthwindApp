using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderPages
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _context;

        public DetailsModel(IOrderService context)
        {
            _context = context;
        }
        public OrderViewModel Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Orders = await _context.GetByIdAsync(id);

            if (Orders == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
