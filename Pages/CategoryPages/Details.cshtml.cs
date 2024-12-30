using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.CategoryPages
{
    public class DetailsModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public CategoryViewModel Category { get; set; } = default!;

        public DetailsModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Category = await _categoryService.GetByIdAsync(id);

                if (Category == null)
                {
                    TempData["Error"] = "Category not exists! Try another one";

                    return RedirectToPage("./Index");
                }
            }
            return Page();
        }
    }
}
