using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository
{
    public interface ISupplierService
    {
        Task<List<SupplierViewModel>> GetAllAsync();

        Task<SupplierViewModel> GetByIdAsync(int id);

        Task InsertAsync(SupplierViewModel product);

        Task UpdateAsync(SupplierViewModel product);

        Task DeleteAsync(int id);
    }
}
