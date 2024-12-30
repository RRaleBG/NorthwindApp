using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderPages
{
    public class DeleteModel(IOrderService orderService, IEmployeeService employeeService, ICustomerService customerService) : PageModel
    {
        private readonly IOrderService _orderService = orderService;
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly ICustomerService _customerService = customerService;

        [BindProperty]
        public OrderViewModel Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Order = await _orderService.GetByIdAsync(id);

            if (Order == null)
            {
                return NotFound();
            }
            else
            {
                Order = Order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Order = await _orderService.GetByIdAsync(id);

            if (Order != null)
            {
                await _orderService.DeleteAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
