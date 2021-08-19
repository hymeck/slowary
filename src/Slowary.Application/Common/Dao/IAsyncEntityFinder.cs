using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Dao
{
    public interface IAsyncEntityFinder<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<Option<TEntity>> FindAsync(TKey id, CancellationToken token = default);
    }
}