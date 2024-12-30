using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.EmployeePages
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public EditModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                NotFound();
            }

            Employee = await _employeeService.GetByIdAsync(id);

            if (Employee == null)
            {
                NotFound();
            }

            ViewData["ReportsTo"] = new SelectList(_employeeService.GetAllAsync().Result.Where(m => m.EmployeeID != id), "EmployeeID", "FirstName");

            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _employeeService.UpdateAsync(Employee);

            return RedirectToPage("./Index");
        }
    }
}