namespace DataLayer.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TodoItem
    {
        [Key]
        public long Id { get; set; }

        public string? Name { get; set; }

        public bool IsComplete { get; set; }

        public string? Secret { get; set; }

        public virtual User? User { get; set; }

        [ForeignKey(nameof(User))]
        public long? UserId { get; set; }
    }
}
