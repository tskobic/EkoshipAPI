namespace BusinessLayer.Interfaces
{
    public interface IService<TCreateUpdateDTO, TDTO, T>
    {
        public Task<IEnumerable<TDTO>> GetAllAsync();
        public Task<TDTO> GetAsync(long id);
        public Task AddAsync(TCreateUpdateDTO itemDTO);
        public Task UpdateAsync(TCreateUpdateDTO itemDTO, long id);
        public Task DeleteAsync(long id);
    }
}
