namespace BusinessLayer.Interfaces
{
    public interface IService<TDTO, T>
    {
        public Task<IEnumerable<TDTO>> GetAllAsync();
        public Task<TDTO> GetAsync(long id);
        public Task AddAsync(TDTO itemDTO);
        public Task UpdateAsync(TDTO itemDTO, long id);
        public Task DeleteAsync(long id);
    }
}
