using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public abstract class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        readonly EkoshipContext _ekoshipContext;

        public DataRepository(EkoshipContext ekoshipContext)
        {
            _ekoshipContext = ekoshipContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ekoshipContext.Set<TEntity>().ToList();
        }

        public TEntity Get(long id)
        {
            return _ekoshipContext.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            _ekoshipContext.Set<TEntity>().Add(entity);
            _ekoshipContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _ekoshipContext.Set<TEntity>().Remove(entity);
            _ekoshipContext.SaveChanges();
        }
    }
}
