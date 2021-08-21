using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageExt;
using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Dao
{
    public interface IAsyncEntityPaginator<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        public Task<Option<(IList<TEntity> Items, int TotalItemsCount)>> GetPaginatedList(int page, int itemsPerPageCount);
    }
}