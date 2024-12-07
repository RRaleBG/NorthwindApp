using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();

        Task<ProductViewModel> GetByIdAsync(int id);

        Task InsertAsync(ProductViewModel product);

        Task UpdateAsync(ProductViewModel product);

        Task DeleteAsync(int id);
    }
}
