using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TransportGlobal.Domain.Repositories;
using TransportGlobal.Domain.SeedWorks;
using TransportGlobal.Infrastructure.Context;

namespace TransportGlobal.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected TransportGlobalDBContext _context;

        public Repository(TransportGlobalDBContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAsEnumerable()
        {
            return _context.Set<T>();
        }

        public T? Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public virtual T? GetByID(int id)
        {
            return _context.Set<T>().Where(x => x.ID == id).FirstOrDefault();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsQueryable().FirstOrDefaultAsync(expression);
        }

        public IEnumerable<T>? GetList(Expression<Func<T, bool>>? expression = null)
        {
            return expression == null ? _context.Set<T>().AsNoTracking() : _context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<T>>? GetListAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression == null ? await _context.Set<T>().ToListAsync() :
                 await _context.Set<T>().Where(expression).ToListAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> ToEnumerable()
        {
            return _context.Set<T>();
        }

        public Task<int> Execute(FormattableString interpolatedQueryString)
        {
            return _context.Database.ExecuteSqlInterpolatedAsync(interpolatedQueryString);
        }

        public TResult? InTransaction<TResult>(Func<TResult> action, Action? successAction = null, Action<Exception>? exceptionAction = null)
        {
            var result = default(TResult);
            try
            {
                if (_context.Database.ProviderName?.EndsWith("InMemory") == true)
                {
                    result = action();
                    SaveChanges();
                }
                else
                {
                    using var tx = _context.Database.BeginTransaction();
                    try
                    {
                        result = action();
                        SaveChanges();
                        tx.Commit();
                    }
                    catch (Exception)
                    {
                        tx.Rollback();
                        throw;
                    }
                }

                successAction?.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionAction == null)
                {
                    throw;
                }

                exceptionAction(ex);
            }
            return result;
        }

        public async Task<int>? GetCountAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression == null ? await _context.Set<T>().CountAsync() : await _context.Set<T>().CountAsync(expression);
        }

        public int? GetCount(Expression<Func<T, bool>>? expression = null)
        {
            return expression == null ? _context.Set<T>().Count() : _context.Set<T>().Count(expression);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>()
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public void DetachEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
