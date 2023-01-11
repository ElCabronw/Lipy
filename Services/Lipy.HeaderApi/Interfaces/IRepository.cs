namespace Lipy.HeaderApi.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<bool> Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task UpdateAsync(TEntity obj);
        Task Remove(Guid id);
    }
}
