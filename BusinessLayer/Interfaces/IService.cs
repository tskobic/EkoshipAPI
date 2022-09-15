namespace BusinessLayer.Interfaces
{
    public interface IService<TDTO, T>
    {
        public IEnumerable<TDTO> GetAll();
        public TDTO Get(long id);
        public void Add(TDTO item);
        public void Update(TDTO item, long id);
        public void Delete(long id);
        public TDTO ItemToDTO(T item);
    }
}
