using System.Threading;
using System.Threading.Tasks;
using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Dao
{
    public interface IAsyncEntityAdder<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);
    }
}