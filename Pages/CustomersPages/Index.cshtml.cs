using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.CustomersPages
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IEnumerable<CustomerViewModel> Customers { get; set; }

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        public async Task OnGetAsync()
        {
            Customers = await _customerService.GetAllAsync();
        }
    }
}
