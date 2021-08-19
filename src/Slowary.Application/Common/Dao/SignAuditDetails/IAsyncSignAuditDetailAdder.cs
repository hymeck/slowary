using Slowary.Domain.Entities;

namespace Slowary.Application.Common.Dao.SignAuditDetails
{
    public interface IAsyncSignAuditDetailAdder : IAsyncEntityAdder<SignAuditDetail, ulong>
    {
    }
}