using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.CustomersPages
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        [BindProperty]
        public CustomerViewModel Customer { get; set; } = default!;

        public EditModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _customerService.GetByIdAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            Customer = Customer;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.UpdateAsync(Customer);

            return RedirectToPage("./Details", new { id = Customer.CustomerID });
        }
    }
}
