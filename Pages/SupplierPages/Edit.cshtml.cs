using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.SupplierPages
{
    public class EditModel : PageModel
    {
        private readonly ISupplierService _service;

        public EditModel(ISupplierService service)
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


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (Supplier != null)
                {
                    await _service.UpdateAsync(Supplier);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Supplier.SupplierID == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
