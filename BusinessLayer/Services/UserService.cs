namespace BusinessLayer.Services
{
    using AutoMapper;
    using BusinessLayer.DTOs;
    using DataLayer.Interfaces;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserService : Service<UserCreateUpdateDTO, UserDTO, User>
    {
        private readonly IDataRepository<User> _userRepository;
        private readonly IDataRepository<TodoItem> _todoItemRepository;
        private readonly IDatabaseScope _databaseScope;

        public UserService(IDataRepository<User> userRepository, 
            IDataRepository<TodoItem> todoItemRepository, IMapper mapper, IDatabaseScope databaseScope)
            : base(userRepository, mapper, databaseScope)
        {
            _userRepository = userRepository;
            _todoItemRepository = todoItemRepository;
            _databaseScope = databaseScope;
        }

        public async override Task AddAsync(UserCreateUpdateDTO userDTO)
        {
            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };

            if (userDTO.TodoItemsIds != null)
            {
                var todoItems = await _todoItemRepository.GetAll().Where(x => userDTO.TodoItemsIds.Contains(x.Id)).ToListAsync();
                user.TodoItems = todoItems;
            }

            await _userRepository.AddAsync(user);
            await _databaseScope.SaveAsync();
        }

        public async override Task UpdateAsync(UserCreateUpdateDTO userDTO, long id)
        {
            User userToUpdate = await _userRepository.GetAsync(id);

            userToUpdate.FirstName = userDTO.FirstName;
            userToUpdate.LastName = userDTO.LastName;

            await _databaseScope.SaveAsync();
        }
    }
}
