using Lipy.HeaderApi.Interfaces;
using MongoDB.Driver;
using ServiceStack;

namespace Lipy.HeaderApi.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IHeaderDbContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IHeaderDbContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<bool> Add(TEntity obj)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
            var changeAmount = await Context.SaveChanges();
            return changeAmount > 0;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
            await Context.SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
            await Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
