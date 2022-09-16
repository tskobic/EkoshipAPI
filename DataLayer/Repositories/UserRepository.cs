namespace DataLayer.Repositories
{
    using DataLayer.Models;

    public class UserRepository : DataRepository<User>
    {
        public UserRepository(EkoshipContext ekoshipContext) : base(ekoshipContext)
        {
        }

    }
}
