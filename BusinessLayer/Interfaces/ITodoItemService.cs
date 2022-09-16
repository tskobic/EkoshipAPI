using BusinessLayer.DTOs;
using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface ITodoItemService : IService<TodoItemDTO, TodoItem>
    {
    }
}
