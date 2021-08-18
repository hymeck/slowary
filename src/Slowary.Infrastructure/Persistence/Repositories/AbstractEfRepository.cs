using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.SomeHelp;
using Microsoft.EntityFrameworkCore;
using Slowary.Application.Common.Repositories;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Repositories
{
    public abstract class AbstractEfRepository<TEntity, TKey, TDbContext> : IAsyncRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        protected AbstractEfRepository(TDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(token);
            return entity;
        }

        public async Task<Option<TEntity>> FindAsync(TKey id, CancellationToken token = default)
        {
            var entity = await _context.Set<TEntity>().FindAsync(new object[] {id}, token);
            return entity?.ToSome() ?? Option<TEntity>.None;
        }
        
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().Update(entity); // todo: may act also as insert
            await _context.SaveChangesAsync(token);
            return entity;
        }
    }
}