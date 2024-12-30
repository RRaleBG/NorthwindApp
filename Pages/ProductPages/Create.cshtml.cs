using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.ProductPages
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierViewModel;

        public CreateModel(IProductService service, ICategoryService categoryService, ISupplierService supplierViewModel)
        {
            _service = service;
            _categoryService = categoryService;
            _supplierViewModel = supplierViewModel;
        }

        public async Task OnGet()
        {
            ViewData["CategoryID"] = new SelectList(await _categoryService.GetAllAsync(), "CategoryID", "CategoryName");
            ViewData["SupplierID"] = new SelectList(await _supplierViewModel.GetAllAsync(), "SupplierID", "CompanyName");
            ViewData["Product"] = new SelectList(await _service.GetAllAsync(), "True", "False");
        }


        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (Product != null)
            {
                await _service.InsertAsync(Product);
            }

            return RedirectToPage("./Index");
        }
    }
}
//Suppliers = await _employeeService.Suppliers.ToListAsync();
//Categories = await _employeeService.Categories.ToListAsync();