

using BusinessLayer.DTOs;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> GetAll();
        public UserDTO Get(long id);
        public void Add(UserDTO userDTO);
        public void Update(UserDTO userDTO, long id);
        public void Delete(long id);
        public UserDTO ItemToDTO(User user);
    }
}
