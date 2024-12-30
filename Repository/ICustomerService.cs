using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllAsync();

        Task<CustomerViewModel> GetByIdAsync(string id);

        Task InsertAsync(CustomerViewModel customer);

        Task UpdateAsync(CustomerViewModel customer);

        Task DeleteAsync(string id);
    }
}
