using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.ProductPages
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public EditModel(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }


        public async Task OnGet(int id)
        {
            Product = await _productService.GetByIdAsync(id);

            ViewData["Product"] = new SelectList(await _productService.GetAllAsync(), "True", "False");
            ViewData["CategoryID"] = new SelectList(await _categoryService.GetAllAsync(), "CategoryID", "CategoryName");
            ViewData["SupplierID"] = new SelectList(await _supplierService.GetAllAsync(), "SupplierID", "CompanyName");
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (Product != null)
            {
                ViewData["Product"] = new SelectList(await _productService.GetAllAsync(), "True", "False");
                ViewData["CategoryID"] = new SelectList(await _categoryService.GetAllAsync(), "CategoryID", "CategoryName");
                ViewData["SupplierID"] = new SelectList(await _supplierService.GetAllAsync(), "SupplierID", "CompanyName");

                await _productService.UpdateAsync(Product);
            }

            return RedirectToPage("./Index");
        }
    }
}
