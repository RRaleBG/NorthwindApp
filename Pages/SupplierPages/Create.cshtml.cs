using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.SupplierPages
{
    public class CreateModel : PageModel
    {
        private readonly ISupplierService _service;

        public CreateModel(ISupplierService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SupplierViewModel Supplier { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Supplier != null)
            {
                await _service.InsertAsync(Supplier);
            }

            return RedirectToPage("./Index");
        }
    }
}
