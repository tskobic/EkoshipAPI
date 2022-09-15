using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class TodoItemRepository : DataRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(EkoshipContext ekoshipContext) : base(ekoshipContext)
        {
        }
    }
}
