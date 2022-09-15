using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IUserRepository : IDataRepository<User>
    {
        void Update(User entityToUpdate, User entity);
    }
}
