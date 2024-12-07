using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllAsync();

        Task<CategoryViewModel> GetByIdAsync(int id);

        Task InsertAsync(CategoryViewModel category);

        Task UpdateAsync(CategoryViewModel category);

        Task DeleteAsync(int id);
    }
}
