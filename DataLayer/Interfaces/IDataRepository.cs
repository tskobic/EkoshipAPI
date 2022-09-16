namespace DataLayer.Interfaces
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
