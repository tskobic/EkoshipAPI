namespace BusinessLayer.DTOs
{
    public class TodoItemCreateUpdateDTO
    {
        public string? Name { get; set; }

        public bool IsComplete { get; set; }
    }

    public class TodoItemDTO : TodoItemCreateUpdateDTO
    {
        public long Id { get; set; }
    }

    public class TodoItemSelectionListDTO
    {
        public long Id { get; set; }

        public string? Name { get; set; }
    }
}
