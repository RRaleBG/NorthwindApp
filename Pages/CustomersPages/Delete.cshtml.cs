using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.CustomersPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public DeleteModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [BindProperty]
        public CustomerViewModel Customer { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id);

            if (customer != null)
            {
                await _customerService.DeleteAsync(id);
            }

            TempData["Success"] = "Success";
            return RedirectToPage("./Index", "Success");
        }
    }
}
