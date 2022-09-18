namespace DataLayer
{
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class EkoshipContextFactory : IDesignTimeDbContextFactory<EkoshipContext>
    {
        public EkoshipContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", false)
           .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EkoshipContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LocalConnection"));

            return new EkoshipContext(optionsBuilder.Options);
        }
    }
}
