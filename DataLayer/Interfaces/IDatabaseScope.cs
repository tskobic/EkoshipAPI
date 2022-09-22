namespace DataLayer.Interfaces
{
    public interface IDatabaseScope
    {
        public Task<int> SaveAsync();
    }
}
