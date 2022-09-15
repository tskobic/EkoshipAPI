using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.Extensions.Logging;

namespace DataLayer.Repositories
{
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        private readonly EkoshipContext _ekoshipContext;
        public UserRepository(EkoshipContext ekoshipContext) : base(ekoshipContext)
        {
            _ekoshipContext = ekoshipContext;
        }

        public void Update(User userToUpdate, User user)
        {
            
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            _ekoshipContext.SaveChanges();
        }
    }
}
