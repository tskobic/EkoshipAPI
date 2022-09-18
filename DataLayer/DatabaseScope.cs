namespace DataLayer
{
    using DataLayer.Interfaces;

    public class DatabaseScope : IDatabaseScope
    {
        private readonly EkoshipContext _ekoshipContext;

        public DatabaseScope(EkoshipContext ekoshipContext)
        {
            _ekoshipContext = ekoshipContext;
        }

        public void SaveAsync()
        {
            _ekoshipContext.SaveChangesAsync();
        }
    }
}
