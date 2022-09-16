namespace DataLayer
{
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore;

    public class EkoshipContextFactory : IDesignTimeDbContextFactory<EkoshipContext>
    {
        public EkoshipContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EkoshipContext>();
            optionsBuilder.UseInMemoryDatabase("Ekoship");

            return new EkoshipContext(optionsBuilder.Options);
        }
    }
}
