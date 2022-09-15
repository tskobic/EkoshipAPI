using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _userRepository.GetAll().Select(x => ItemToDTO(x)).ToList();
        }

        public UserDTO Get(long id)
        {
            User user = _userRepository.Get(id);
            if (user == null)
            {
                return null;
            }
            return ItemToDTO(user);
        }

        public void Add(UserDTO userDTO)
        {
            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };

            _userRepository.Add(user);
        }

        public void Update(UserDTO userDTO, long id)
        {
            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };

            User userToUpdate = _userRepository.Get(id);

            _userRepository.Update(userToUpdate, user);
        }

        public void Delete(long id)
        {
            var user = _userRepository.Get(id);
            _userRepository.Delete(user);
        }

        public UserDTO ItemToDTO(User user) =>
            new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
    }
}
