using Slowary.Application.Common.Dao.SignAuditDetails;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao.SignAuditDetails
{
    public class EfAsyncSignAuditDetailAdder : EfAsyncEntityAdderBase<SignAuditDetail, ulong, ApplicationDbContext>, IAsyncSignAuditDetailAdder
    {
        public EfAsyncSignAuditDetailAdder(ApplicationDbContext context) : base(context)
        {
        }
    }
}