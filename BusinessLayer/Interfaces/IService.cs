using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface IService<TDTO, T>
    {
        public Task<IEnumerable<TDTO>> GetAll();
        public Task<TDTO> Get(long id);
        public Task Add(TDTO itemDTO);
        public Task Update(TDTO itemDTO, long id);
        public Task Delete(long id);
    }
}
