namespace BusinessLayer.Services
{
    using AutoMapper;
    using BusinessLayer.DTOs;
    using DataLayer;
    using DataLayer.Interfaces;
    using DataLayer.Models;

    public class TodoItemService : Service<TodoItemDTO, TodoItem>
    {
        private readonly IDataRepository<TodoItem> _todoItemRepository;
        private readonly DatabaseScope _databaseScope;

        public TodoItemService(IDataRepository<TodoItem> todoItemRepository, IMapper mapper, DatabaseScope databaseScope) 
            : base(todoItemRepository, mapper, databaseScope)
        {
            _todoItemRepository = todoItemRepository;
            _databaseScope = databaseScope;
        }

        public async override Task Add(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                Name = todoItemDTO.Name,
                IsComplete = todoItemDTO.IsComplete
            };

            await _todoItemRepository.Add(todoItem);
            _databaseScope.Save();
        }

        public async override Task Update(TodoItemDTO todoItemDTO, long id)
        {
            TodoItem todoItemToUpdate = await _todoItemRepository.Get(id);

            todoItemToUpdate.Name = todoItemDTO.Name;
            todoItemToUpdate.IsComplete = todoItemDTO.IsComplete;

            _databaseScope.Save();
        }
    }
}
