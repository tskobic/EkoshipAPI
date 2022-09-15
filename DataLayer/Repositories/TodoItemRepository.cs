using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class TodoItemRepository : DataRepository<TodoItem>, ITodoItemRepository
    {
        private readonly EkoshipContext _ekoshipContext;
        public TodoItemRepository(EkoshipContext ekoshipContext) : base(ekoshipContext)
        {
            _ekoshipContext = ekoshipContext;
        }

        public void Update(TodoItem todoItemToUpdate, TodoItem todoItem)
        {

            todoItemToUpdate.Name = todoItem.Name;
            todoItemToUpdate.IsComplete = todoItem.IsComplete;
            _ekoshipContext.SaveChanges();
        }
    }
}
