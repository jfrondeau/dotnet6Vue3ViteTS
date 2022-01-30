using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnePunchDbContext.Models;

namespace OnePunchDbContext
{
    public class OnePunchContext : DbContext
    {
        public OnePunchContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This will singularize all table names
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
        }

        public DbSet<Orotime> Orotimes => Set<Orotime>();
    }
}
