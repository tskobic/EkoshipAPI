using BusinessLayer.DTOs;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService : IService<UserDTO, User>
    {
    }
}
