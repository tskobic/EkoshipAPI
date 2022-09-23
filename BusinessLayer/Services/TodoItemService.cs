namespace BusinessLayer.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BusinessLayer.DTOs;
    using BusinessLayer.Interfaces;
    using DataLayer.Interfaces;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;

    public class TodoItemService 
        : Service<TodoItemCreateUpdateDTO, TodoItemDTO, TodoItem>, 
        ITodoItemService<TodoItemSelectionListDTO, TodoItemCreateUpdateDTO, TodoItemDTO, TodoItem>
    {
        private readonly IDataRepository<TodoItem> _todoItemRepository;
        private readonly IDatabaseScope _databaseScope;
        private readonly IMapper _mapper;

        public TodoItemService(IDataRepository<TodoItem> todoItemRepository, IMapper mapper, IDatabaseScope databaseScope)
            : base(todoItemRepository, mapper, databaseScope)
        {
            _todoItemRepository = todoItemRepository;
            _databaseScope = databaseScope;
            _mapper = mapper;
        }

        public async override Task AddAsync(TodoItemCreateUpdateDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                Name = todoItemDTO.Name,
                IsComplete = todoItemDTO.IsComplete
            };

            await _todoItemRepository.AddAsync(todoItem);
            await _databaseScope.SaveAsync();
        }

        public async override Task UpdateAsync(TodoItemCreateUpdateDTO todoItemDTO, long id)
        {
            TodoItem todoItemToUpdate = await _todoItemRepository.GetAsync(id);

            todoItemToUpdate.Name = todoItemDTO.Name;
            todoItemToUpdate.IsComplete = todoItemDTO.IsComplete;

            await _databaseScope.SaveAsync();
        }

        public async Task<IEnumerable<TodoItemSelectionListDTO>> GetSelectionListAsync()
        {
            var items = await _todoItemRepository.AsReadOnly()
                .Where(x => x.UserId == null).ProjectTo<TodoItemSelectionListDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return items;
        }
    }
}
