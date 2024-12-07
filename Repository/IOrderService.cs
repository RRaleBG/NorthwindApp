using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository
{
    public interface IOrderService
    {
        Task<IList<OrderViewModel>> GetAllAsync();

        Task<OrderViewModel> GetByIdAsync(int id);

        Task InsertAsync(OrderViewModel order);

        Task UpdateAsync(OrderViewModel order);

        Task DeleteAsync(int id);
    }
}
