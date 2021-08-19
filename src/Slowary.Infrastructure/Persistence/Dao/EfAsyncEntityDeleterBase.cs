using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.SomeHelp;
using Microsoft.EntityFrameworkCore;
using Slowary.Application.Common.Dao;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao
{
    public class EfAsyncEntityDeleterBase<TEntity, TKey, TDbContext> : IAsyncEntityDeleter<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public EfAsyncEntityDeleterBase(TDbContext context)
        {
            _context = context;
        }

        public async Task<Option<TEntity>> DeleteAsync(TEntity entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().Remove(entity);
            var affectedRows = await _context.SaveChangesAsync(token);
            return affectedRows == 0 ? entity.ToSome() : Option<TEntity>.None;
        }
    }
}