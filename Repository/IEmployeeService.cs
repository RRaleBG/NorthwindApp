using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllAsync();

        Task<EmployeeViewModel> GetByIdAsync(int id);

        Task InsertAsync(EmployeeViewModel customer);

        Task UpdateAsync(EmployeeViewModel customer);

        Task DeleteAsync(int id);

        public string GetReportsTo(int id);
    }
}
