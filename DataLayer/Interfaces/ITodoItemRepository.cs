using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface ITodoItemRepository : IDataRepository<TodoItem>
    {
        void Update(TodoItem todoItemToUpdate, TodoItem todoItem);
    }
}
