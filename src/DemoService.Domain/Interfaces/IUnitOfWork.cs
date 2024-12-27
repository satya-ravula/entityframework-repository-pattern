namespace DemoService.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T, TId> Repository<T, TId>() where T : class, IIdentifiable<TId>;
        Task<bool> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
