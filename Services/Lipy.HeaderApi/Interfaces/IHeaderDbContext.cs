using MongoDB.Driver;

namespace Lipy.HeaderApi.Interfaces
{
    public interface IHeaderDbContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
