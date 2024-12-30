using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.CategoryPages
{
    public class EditModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public EditModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public CategoryViewModel Category { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                NotFound();
            }

            Category = await _categoryService.GetByIdAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (Category == null)
            {
                return NotFound();
            }

            await _categoryService.UpdateAsync(Category);

            return RedirectToPage("./Index");
        }
    }
}