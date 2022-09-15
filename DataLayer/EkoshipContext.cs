using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using DataLayer.Models;

namespace DataLayer
{
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
