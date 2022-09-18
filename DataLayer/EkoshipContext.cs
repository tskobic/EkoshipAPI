namespace DataLayer
{
    using Microsoft.EntityFrameworkCore;
    using DataLayer.Models;
    using System.Reflection.Metadata;

    public class EkoshipContext : DbContext
    {
        public EkoshipContext(DbContextOptions<EkoshipContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TodoItem>()
                .HasOne(e => e.User)
                .WithMany(e => e.TodoItems)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
