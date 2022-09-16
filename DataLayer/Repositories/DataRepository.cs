namespace DataLayer.Repositories
{
    using DataLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public abstract class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        readonly EkoshipContext _ekoshipContext;

        public DataRepository(EkoshipContext ekoshipContext)
        {
            _ekoshipContext = ekoshipContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _ekoshipContext.Set<TEntity>();
        }

        public async Task<TEntity> Get(long id)
        {
            return await _ekoshipContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            await _ekoshipContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _ekoshipContext.Set<TEntity>().Remove(entity);
        }
    }
}
