namespace BusinessLayer.DTOs
{
    public class UserDTO : UserCreateUpdateDTO
    {
        public long Id { get; set; }
    }

    public class UserCreateUpdateDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public ICollection<TodoItemDTO>? TodoItems { get; set; }
    }
}
