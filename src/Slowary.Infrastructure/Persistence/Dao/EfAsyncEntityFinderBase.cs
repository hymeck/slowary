using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.SomeHelp;
using Microsoft.EntityFrameworkCore;
using Slowary.Application.Common.Dao;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao
{
    public class EfAsyncEntityFinderBase<TEntity, TKey, TDbContext> : IAsyncEntityFinder<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public EfAsyncEntityFinderBase(TDbContext context)
        {
            _context = context;
        }

        public async Task<Option<TEntity>> FindAsync(TKey id, CancellationToken token = default)
        {
            var entity = await _context.Set<TEntity>().FindAsync(new object[] {id}, token);
            return entity?.ToSome() ?? Option<TEntity>.None;
        }
    }
}