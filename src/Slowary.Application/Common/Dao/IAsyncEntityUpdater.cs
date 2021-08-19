using System.Threading;
using System.Threading.Tasks;
using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Dao
{
    public interface IAsyncEntityUpdater<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default);
    }
}