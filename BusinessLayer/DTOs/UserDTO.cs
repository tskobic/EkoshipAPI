using DataLayer.Models;

namespace BusinessLayer.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<TodoItemDTO>? TodoItems { get; set; }
    }
}
