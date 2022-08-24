using Microsoft.EntityFrameworkCore;
using PapoDeDev.Domain.Entities;

namespace PapoDeDevAPI.Data
{
    public class DevContext : DbContext
    {
        public DevContext(DbContextOptions<DevContext> options) : base(options) { }

        public DbSet<Developer> Developers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
