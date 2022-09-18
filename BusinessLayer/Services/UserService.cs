namespace BusinessLayer.Services
{
    using AutoMapper;
    using BusinessLayer.DTOs;
    using DataLayer.Interfaces;
    using DataLayer.Models;

    public class UserService : Service<UserDTO, User>
    {
        private readonly IDataRepository<User> _userRepository;
        private readonly IDatabaseScope _databaseScope;

        public UserService(IDataRepository<User> userRepository, IMapper mapper, IDatabaseScope databaseScope)
            : base(userRepository, mapper, databaseScope)
        {
            _userRepository = userRepository;
            _databaseScope = databaseScope;
        }

        public async override Task AddAsync(UserDTO userDTO)
        {
            List<TodoItem> addedTodoItems = new List<TodoItem>();

            if (userDTO.TodoItems != null)
            {
                foreach (var item in userDTO.TodoItems)
                {
                    var todoItem = new TodoItem
                    {
                        Name = item.Name,
                        IsComplete = item.IsComplete
                    };

                    addedTodoItems.Add(todoItem);
                }
            }

            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                TodoItems = addedTodoItems,
            };

            await _userRepository.AddAsync(user);
            _databaseScope.SaveAsync();
        }

        public async override Task UpdateAsync(UserDTO userDTO, long id)
        {
            User userToUpdate = await _userRepository.GetAsync(id);

            userToUpdate.FirstName = userDTO.FirstName;
            userToUpdate.LastName = userDTO.LastName;

            _databaseScope.SaveAsync();
        }
    }
}
