using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;


namespace NorthwindApp.Pages.CustomersPages
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomerViewModel Customer { get; set; } = default!;


        public DetailsModel( ICustomerService customerService)
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

            return Page();
        }
    }
}
