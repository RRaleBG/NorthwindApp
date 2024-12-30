using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.EmployeePages
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeService _service;

        public DeleteModel(IEmployeeService service)
        {
            _service = service;
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Employee = await _service.GetByIdAsync(id);

            if (Employee == null)
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

            Employee = await _service.GetByIdAsync(id);

            if (Employee != null)
            {
                await _service.DeleteAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
