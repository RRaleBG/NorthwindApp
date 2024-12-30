using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.ProductPages
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _context;

        public DeleteModel(IProductService context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Product = await _context.GetByIdAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Product = await _context.GetByIdAsync(id);

            if (Product != null)
            {
                await _context.DeleteAsync(id);
            }

            TempData["Success"] = "Success";

            return RedirectToPage("./Index");
        }
    }
}