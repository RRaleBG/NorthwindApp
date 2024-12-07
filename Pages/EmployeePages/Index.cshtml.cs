using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;


namespace NorthwindApp.Pages.EmployeePages
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public IEnumerable<EmployeeViewModel> Employee { get; set; }

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        public async Task OnGetAsync()
        {
            //ViewData["ReportsTo"] = new SelectList(_employeeService.GetAllAsync().Result.Where(m => m.EmployeeID != 0), "EmployeeID", "FirstName");
            Employee = await _employeeService.GetAllAsync();

            if (Employee == null)
            {
                BadRequest();
            }
        }
    }
}
