using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.EmployeePages
{
    public class CreateModel : PageModel
    {    
        private readonly IEmployeeService _employeeService;

        public CreateModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ReportsTo"] = new SelectList(await _employeeService.GetAllAsync(), "EmployeeID", "FirstName");
            return Page();
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; } 

        public async Task<IActionResult> OnPostAsync()
        {
            await _employeeService.InsertAsync(Employee);

            return RedirectToPage("./Index");
        }
    }
}
