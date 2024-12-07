namespace NorthwindApp.Repository
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAllAsync();

        Task GetByIdAsync(int? id);

        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);

    }
}
