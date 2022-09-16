namespace DataLayer
{
    public class DatabaseScope
    {
        private readonly EkoshipContext _ekoshipContext;

        public DatabaseScope(EkoshipContext ekoshipContext)
        {
            _ekoshipContext = ekoshipContext;
        }

        public void Save()
        {
            _ekoshipContext.SaveChangesAsync();
        }
    }
}
