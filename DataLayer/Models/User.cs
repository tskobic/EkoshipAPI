namespace DataLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; }

        [InverseProperty(nameof(TodoItem.User))]
        public virtual ICollection<TodoItem>? TodoItems { get; set; } = new List<TodoItem>();
    }
}
