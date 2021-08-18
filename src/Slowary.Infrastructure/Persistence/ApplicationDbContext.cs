using Microsoft.EntityFrameworkCore;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sign> Signs => Set<Sign>();
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}