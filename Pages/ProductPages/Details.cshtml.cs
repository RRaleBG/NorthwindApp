using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.ProductPages
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _context;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public IEnumerable<ProductViewModel> Products { get; set; }

        public DetailsModel(IProductService context, ICategoryService categoryService, ISupplierService supplierService)
        {
            _context = context;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        public ProductViewModel Product { get; set; } = default!;
        public SupplierViewModel Supplier { get; set; } = default!;
        public CategoryViewModel Category { get; set; } = default!;



        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Product = await _context.GetByIdAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
