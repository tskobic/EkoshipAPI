namespace BusinessLayer.Services
{
    using AutoMapper;
    using BusinessLayer.DTOs;
    using DataLayer;
    using DataLayer.Interfaces;
    using DataLayer.Models;

    public class UserService : Service<UserDTO, User>
    {
        private readonly IDataRepository<User> _userRepository;
        private readonly DatabaseScope _databaseScope;

        public UserService(IDataRepository<User> userRepository, IMapper mapper, DatabaseScope databaseScope) 
            : base(userRepository, mapper, databaseScope)
        {
            _userRepository = userRepository;
            _databaseScope = databaseScope;
        }

        public async override Task Add(UserDTO userDTO)
        {
            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };

            await _userRepository.Add(user);
            _databaseScope.Save();
        }

        public async override Task Update(UserDTO userDTO, long id)
        {
            User userToUpdate = await _userRepository.Get(id);
            userToUpdate.FirstName = userDTO.FirstName;
            userToUpdate.LastName = userDTO.LastName;
            _databaseScope.Save();
        }
    }
}
