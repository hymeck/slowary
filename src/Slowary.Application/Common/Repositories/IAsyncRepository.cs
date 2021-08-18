using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Repositories
{
    public interface IAsyncRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);
        Task<Option<TEntity>> FindAsync(TKey id, CancellationToken token = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default);
    }

    public interface ISignAsyncRepository : IAsyncRepository<Sign, ulong>
    {
    }
}