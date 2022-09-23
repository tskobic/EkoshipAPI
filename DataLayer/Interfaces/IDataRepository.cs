namespace DataLayer.Interfaces
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> AsReadOnly();

        Task<TEntity> GetAsync(long id);

        Task AddAsync(TEntity entity);

        void Delete(TEntity entity);
    }
}
