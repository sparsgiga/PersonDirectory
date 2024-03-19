using System.Linq.Expressions;

namespace PersonDirectory.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(IQueryable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query(params Expression<Func<T, object>>[] includes);
    }
}
