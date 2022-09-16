using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace BusinessLayer.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public IEnumerable<TodoItemDTO> GetAll()
        {
            return _todoItemRepository.GetAll().Select(x => ItemToDTO(x)).ToList();
        }

        public TodoItemDTO Get(long id)
        {
            TodoItem todoItem = _todoItemRepository.Get(id);
            if (todoItem == null)
            {
                return null;
            }
            return ItemToDTO(todoItem);
        }

        public void Add(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                Name = todoItemDTO.Name,
                IsComplete = todoItemDTO.IsComplete
            };

            _todoItemRepository.Add(todoItem);
        }

        public void Update(TodoItemDTO todoItemDTO, long id)
        {
            var todoItem = new TodoItem
            {
                Name = todoItemDTO.Name,
                IsComplete = todoItemDTO.IsComplete
            };

            TodoItem todoItemToUpdate = _todoItemRepository.Get(id);

            _todoItemRepository.Update(todoItemToUpdate, todoItem);
        }

        public void Delete(long id)
        {
            var todoItem = _todoItemRepository.Get(id);
            _todoItemRepository.Delete(todoItem);
        }

        public TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}
