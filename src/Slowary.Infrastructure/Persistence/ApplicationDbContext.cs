using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sign> Signs => Set<Sign>();
        public DbSet<SignAuditDetail> SignAuditDetail => Set<SignAuditDetail>();
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // apply implementations of IEntityTypeConfiguration
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}