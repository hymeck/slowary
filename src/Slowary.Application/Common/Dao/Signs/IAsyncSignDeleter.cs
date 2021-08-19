using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Dao.Signs
{
    public interface IAsyncSignDeleter : IAsyncEntityDeleter<Sign, ulong>
    {
    }
}