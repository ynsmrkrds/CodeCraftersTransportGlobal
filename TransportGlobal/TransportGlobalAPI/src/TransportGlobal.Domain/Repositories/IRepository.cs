using System.Linq.Expressions;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        T? GetByID(int id);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAsEnumerable();

        IEnumerable<T>? GetList(Expression<Func<T, bool>>? expression = null);

        Task<IEnumerable<T>>? GetListAsync(Expression<Func<T, bool>>? expression = null);

        T? Get(Expression<Func<T, bool>> expression);

        Task<T?> GetAsync(Expression<Func<T, bool>> expression);

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IQueryable<T> Query();

        Task<int> Execute(FormattableString interpolatedQueryString);

        TResult? InTransaction<TResult>(Func<TResult> action, Action? successAction = null, Action<Exception>? exceptionAction = null);

        Task<int>? GetCountAsync(Expression<Func<T, bool>>? expression = null);

        int? GetCount(Expression<Func<T, bool>>? expression = null);

        void DetachEntity(T entity);
    }
}
