using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderPages
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _context;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;

        public EditModel(IOrderService context, ICustomerService customerService, IEmployeeService employeeService)
        {
            _context = context;
            _customerService = customerService;
            _employeeService = employeeService;
        }

        [BindProperty]
        public OrderViewModel Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Order = await _context.GetByIdAsync(id);

            ViewData["CustomerID"] = new SelectList(await _customerService.GetAllAsync(), "CustomerID", "CompanyName");
            ViewData["EmployeeID"] = new SelectList(await _employeeService.GetAllAsync(), "EmployeeID", "FirstName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {  
            if(Order.OrderID != 0)
            {           
                try
                {
                    await _context.UpdateAsync(Order);
                    return RedirectToPage("./Details", new { id = Order.OrderID });
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (Order == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw new DbUpdateException(ex.Message);
                    }
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
