using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderPages
{
    public class CreateModel(IOrderService orderService, IEmployeeService employeeService, ICustomerService customerService) : PageModel
    {
        private readonly IOrderService _orderService = orderService;
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly ICustomerService _customerService = customerService;

        public async Task OnGetAsync()
        {
            ViewData["CustomerID"] = new SelectList(await _customerService.GetAllAsync(), "CustomerID", "CompanyName");
            ViewData["EmployeeID"] = new SelectList(await _employeeService.GetAllAsync(), "EmployeeID", "FirstName");
            //Orders = await _orderDetailService.Orders
            //    .Include(o => o.Customer)
            //    .Include(o => o.Employee).Where(m => m.OrderID == id).FirstOrDefaultAsync();

            //ViewData["CustomerID"] = new SelectList(_orderDetailService.Orders.Include(m=>m.Customer), "CustomerID", "CompanyName");
            //ViewData["EmployeeID"] = new SelectList(_orderDetailService.Orders.Include(s=>s.Employee).Distinct(), "EmployeeID", "FirstName");
        }


        [BindProperty]
        public OrderViewModel Order { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync(OrderViewModel order)
        {
            //string message = "";

            //if(!ModelState.IsValid)
            //{
            //    message = "Order; " + order.OrderID + " ordered by: " + order.Customer.ContactName + " not ordered";

            //    return Content(message);
            //}
            if (Order != null)
            {
                await _orderService.InsertAsync(Order);
                TempData["Success"] = "New order inserted successfully!" + await _orderService.GetByIdAsync(Order.OrderID - 1);

                return RedirectToPage("./Index");
            }
            else
            {
                TempData["Error"] = "Category not exists! Try another one";

                return RedirectToPage("./Create");
            }
        }
    }
}
