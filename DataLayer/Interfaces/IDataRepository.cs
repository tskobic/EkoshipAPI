namespace DataLayer.Interfaces
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetAsync(long id);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}
