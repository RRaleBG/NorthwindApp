using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;
using NuGet.Protocol;


namespace NorthwindApp.Pages.CustomersPages
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _customerService;

        [BindProperty]
        public CustomerViewModel Customer { get; set; }

        public CreateModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Customer != null)
            {
                await _customerService.InsertAsync(Customer);
                TempData["Success"] = Customer.ToJson();  
            }
            else
            {
                TempData["Error"] = "Not added!";
            }

            return RedirectToPage("./Details", new {id = Customer.CustomerID });
        }
    }
}
