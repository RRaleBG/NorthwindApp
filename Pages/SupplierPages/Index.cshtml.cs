using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.SupplierPages
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierService _supplierContext;

        public IndexModel(ISupplierService supplierContext)
        {
            _supplierContext = supplierContext;
        }

        public List<SupplierViewModel> Supplier { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Supplier = await _supplierContext.GetAllAsync();
        }
    }
}
