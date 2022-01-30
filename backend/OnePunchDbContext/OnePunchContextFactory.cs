using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnePunchDbContext
{
    public class OnePunchContextFactory : IDesignTimeDbContextFactory<OnePunchContext>
    {
        public OnePunchContextFactory()
        {
        }

        public OnePunchContext CreateDbContext(string[] args)
        {
            var connectionStringName = "default";
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrEmpty(environmentName))
            {
                environmentName = "Development";
            }

            Console.WriteLine("Environnement: {0}", environmentName);
            
            var appBasePath = Directory.GetCurrentDirectory() + "/../OnePunchApi";

            var config = new ConfigurationBuilder()
                .SetBasePath(appBasePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .Build();

            var connectionString = config.GetConnectionString("default");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException($"Could not find a connection string named '{connectionStringName}'.");
            }

            var builder = new DbContextOptionsBuilder<OnePunchContext>();
            builder.UseSqlite(connectionString);
            
            return new OnePunchContext(builder.Options);
        }
    }
}
