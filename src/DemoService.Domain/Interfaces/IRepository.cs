using System.Linq.Expressions;

namespace DemoService.Domain.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class, IIdentifiable<TId>
    {
        Task<TEntity?> Get(TId id);
        Task<TEntity?> Get(TId id, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        Task Remove(TId id);
    }
}
