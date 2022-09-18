namespace BusinessLayer.Services
{
    using AutoMapper;
    using BusinessLayer.DTOs;
    using DataLayer.Interfaces;
    using DataLayer.Models;

    public class TodoItemService : Service<TodoItemDTO, TodoItem>
    {
        private readonly IDataRepository<TodoItem> _todoItemRepository;
        private readonly IDatabaseScope _databaseScope;

        public TodoItemService(IDataRepository<TodoItem> todoItemRepository, IMapper mapper, IDatabaseScope databaseScope) 
            : base(todoItemRepository, mapper, databaseScope)
        {
            _todoItemRepository = todoItemRepository;
            _databaseScope = databaseScope;
        }

        public async override Task AddAsync(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                Name = todoItemDTO.Name,
                IsComplete = todoItemDTO.IsComplete
            };

            await _todoItemRepository.AddAsync(todoItem);
            _databaseScope.SaveAsync();
        }

        public async override Task UpdateAsync(TodoItemDTO todoItemDTO, long id)
        {
            TodoItem todoItemToUpdate = await _todoItemRepository.GetAsync(id);

            todoItemToUpdate.Name = todoItemDTO.Name;
            todoItemToUpdate.IsComplete = todoItemDTO.IsComplete;

            _databaseScope.SaveAsync();
        }
    }
}
