using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.SupplierPages
{
    public class DeleteModel : PageModel
    {
        private readonly ISupplierService _service;

        public DeleteModel(ISupplierService service)
        {
            _service = service;
        }

        [BindProperty]
        public SupplierViewModel Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Supplier = await _service.GetByIdAsync(id);

            if (Supplier == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Supplier = await _service.GetByIdAsync(id);

            if (Supplier != null)
            {
                await _service.DeleteAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}

