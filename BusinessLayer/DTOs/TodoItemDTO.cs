namespace BusinessLayer.DTOs
{
    public class TodoItemDTO : TodoItemCreateUpdateDTO
    {
        public long Id { get; set; }
    }

    public class TodoItemCreateUpdateDTO
    {
        public string? Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
