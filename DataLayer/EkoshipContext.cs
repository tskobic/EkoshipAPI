namespace DataLayer
{
    using Microsoft.EntityFrameworkCore;
    using DataLayer.Models;

    public class EkoshipContext : DbContext
    {
        public EkoshipContext(DbContextOptions<EkoshipContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
