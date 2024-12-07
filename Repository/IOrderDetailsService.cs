using Northwind.Models;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetailsViewModel>> GetAllAsync();

        Task<OrderDetailsViewModel> GetByIdAsync(int id, int id2);

        Task InsertAsync(OrderDetailsViewModel orderDetails);

        Task UpdateAsync(OrderDetailsViewModel orderDetails);

        Task DeleteAsync(int id);
    }
}
