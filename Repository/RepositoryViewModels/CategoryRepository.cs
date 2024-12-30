using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class CategoryRepository : ICategoryService
    {
        private readonly NorthwindDBContext _context;

        public CategoryRepository(NorthwindDBContext context)
        {
            _context = context;
        }

        // Delete Category information
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }


        // Get Category information by id
        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            if (id != 0)
            {
                var category = await _context.Categories.FindAsync(id);

                if (category != null)
                {
                    var categoryViewModel = new CategoryViewModel
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        Description = category.Description,
                        Picture = category.Picture
                    };

                    return categoryViewModel;
                }
            }
            return null;
        }


        // Insert Category information
        public async Task InsertAsync(CategoryViewModel category)
        {
            byte[] bytes = null;

            if (category.PictureInput != null)
            {
                using Stream ms = category.PictureInput.OpenReadStream();
                using (BinaryReader br = new(ms))
                {
                    bytes = br.ReadBytes((Int32)ms.Length);
                }
                category.Picture = bytes;
                //category.Picture = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            var newCategory = new Category
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = bytes,
                //Picture = category.Picture,
            };
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
        }


        // Update Category information
        public async Task UpdateAsync(CategoryViewModel category)
        {
            var categoryViewModel = await _context.Categories.FindAsync(category.CategoryID);

            byte[] bytes = null;

            if (category.PictureInput != null)
            {
                using Stream ms = category.PictureInput.OpenReadStream();
                using (BinaryReader br = new(ms))
                {
                    bytes = br.ReadBytes((Int32)ms.Length);
                }
                category.Picture = bytes;
                //category.Picture = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            if (categoryViewModel != null)
            {
                categoryViewModel.CategoryID = category.CategoryID;
                categoryViewModel.CategoryName = category.CategoryName;
                categoryViewModel.Description = category.Description;
                categoryViewModel.Picture = category.Picture;

                _context.Categories.Update(categoryViewModel);
                await _context.SaveChangesAsync();
            }
        }


        // Get all Categories to list
        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            List<Category> categories = await _context.Categories.AsNoTracking().ToListAsync();
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                var _categoryViewModel = new CategoryViewModel
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    Picture = category.Picture
                };

                if (_categoryViewModel != null)
                {
                    categoryViewModels.Add(_categoryViewModel);
                }
            }
            return categoryViewModels;
        }
    }
}