using System.Linq.Expressions;

namespace TravelEstates.Data.Abstraction.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> FindEntityAsync(Expression<Func<T, bool>> expression);

        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
