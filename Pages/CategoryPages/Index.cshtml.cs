using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public string Message { get; set; }

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

       
        public IEnumerable<CategoryViewModel> Category { get;set; }
        public async Task<IActionResult> OnGetAsync()
        {             
            Category = await _categoryService.GetAllAsync();

            if(Category == null)
            {
                Message = "Category not found!";
                return Page();
            }
            return Page();
        }
    }
}