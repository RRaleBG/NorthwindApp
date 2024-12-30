using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.CategoryPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(ICategoryService categoryService, ILogger<DeleteModel> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [BindProperty]
        public CategoryViewModel Category { get; set; } = default!;
        public string Message { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError = false)
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
                    return RedirectToPage("Index", Message = $"Delete {id} failed. Please try again!", id);
                }
            }

            if (saveChangesError.GetValueOrDefault())
            {
                Message = $"Deleting {Category.CategoryName} failed. Please try again!";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, bool? saveChangesError = false)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Category = await _categoryService.GetByIdAsync(id);

                if (Category != null)
                {
                    try
                    {
                        await _categoryService.DeleteAsync(id);
                        Message = $"Category with id: {Category.CategoryName} succesfully deleted.";
                        return RedirectToPage("Index", Message);
                    }
                    catch (DbUpdateException ex)
                    {
                        _logger.LogError(ex.Message);
                        return RedirectToAction(nameof(DeleteModel), new { id, saveChangesError = true });
                    }
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
