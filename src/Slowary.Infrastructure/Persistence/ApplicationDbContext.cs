using Microsoft.EntityFrameworkCore;
using Slowary.Application.Common.Contexts;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Sign> Signs => Set<Sign>();
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbContext Context => this;
    }
}