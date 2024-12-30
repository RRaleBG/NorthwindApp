using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.SupplierPages
{
    public class DetailsModel : PageModel
    {
        private readonly ISupplierService _context;

        public DetailsModel(ISupplierService context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplierViewModel Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Supplier = await _context.GetByIdAsync(id);

            if (Supplier == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
