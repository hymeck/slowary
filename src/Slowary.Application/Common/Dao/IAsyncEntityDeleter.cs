using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Dao
{
    public interface IAsyncEntityDeleter<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<Option<TEntity>> DeleteAsync(TEntity entity, CancellationToken token = default);
    }
}