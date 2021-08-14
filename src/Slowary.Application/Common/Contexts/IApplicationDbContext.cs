using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Slowary.Application.Common.Contexts
{
    public interface IApplicationDbContext
    {
        DbContext Context { get; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}