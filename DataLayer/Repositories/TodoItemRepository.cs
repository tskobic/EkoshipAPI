namespace DataLayer.Repositories
{
    using DataLayer.Models;

    public class TodoItemRepository : DataRepository<TodoItem>
    {
        public TodoItemRepository(EkoshipContext ekoshipContext) : base(ekoshipContext)
        {
        }
    }
}
