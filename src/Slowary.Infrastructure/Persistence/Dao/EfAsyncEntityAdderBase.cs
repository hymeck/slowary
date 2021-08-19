using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slowary.Application.Common.Dao;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao
{
    public abstract class EfAsyncEntityAdderBase<TEntity, TKey, TDbContext> : IAsyncEntityAdder<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        protected EfAsyncEntityAdderBase(TDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(token);
            return entity;
        }
    }
}