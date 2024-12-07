using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.EmployeePages
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public DetailsModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; } = default!;
        public string sefNastojka = string.Empty;
        
        public async Task<IActionResult> OnGetAsync(int id)
        {         
            if (id == 0)
            {
                return NotFound();
            }
            Employee = await _employeeService.GetByIdAsync(id);
            
            //sefNastojka = _employeeService.GetReportsTo(id);
         

            ViewData["ReportsTo"] = new SelectList(_employeeService.GetAllAsync().Result.Where(m => m.EmployeeID != id), "EmployeeID", "FirstName");
            //if(sefNastojka == null) { return (IActionResult)(ViewData["ReportsTo"] = null); }
   
            return Page();     
        }
    }
}
