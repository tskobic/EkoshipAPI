namespace BusinessLayer.DTOs
{
    public class UserBaseDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }

    public class UserCreateUpdateDTO : UserBaseDTO
    {
        public ICollection<long>? TodoItemsIds { get; set; }
    }

    public class UserDTO : UserBaseDTO
    {
        public long Id { get; set; }

        public ICollection<TodoItemDTO>? TodoItems { get; set; }
    }
}
