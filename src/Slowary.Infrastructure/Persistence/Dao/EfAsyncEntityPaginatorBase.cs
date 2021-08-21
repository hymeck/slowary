using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.SomeHelp;
using Microsoft.EntityFrameworkCore;
using Slowary.Application.Common.Dao;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao
{
    public class EfAsyncEntityPaginatorBase<TEntity, TKey, TDbContext> : IAsyncEntityPaginator<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public EfAsyncEntityPaginatorBase(TDbContext context)
        {
            _context = context;
        }
        
        // todo: test if itemsPerPageCount > totalCount
        public async Task<Option<(IList<TEntity> Items, int TotalItemsCount)>> GetPaginatedList(int page, int itemsPerPageCount)
        {
            // todo really there?
            if (page < 1 || itemsPerPageCount < 1)
                return Option<(IList<TEntity> Items, int TotalItemsCount)>.None;
            
            var source = _context.Set<TEntity>()
                .AsQueryable();
            
            var totalCount = await source.CountAsync();
            
            var items = await source
                .Skip((page - 1) * itemsPerPageCount)
                .Take(itemsPerPageCount)
                .OrderBy(e => e.Id)
                .ToListAsync();

            return ((IList<TEntity>) items, totalCount).ToSome();
        }
    }
}