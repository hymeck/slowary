using Slowary.Application.Common.Dao.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao.Signs
{
    public class EfAsyncSignUpdater : EfAsyncEntityUpdaterBase<Sign, ulong, ApplicationDbContext>, IAsyncSignUpdater
    {
        public EfAsyncSignUpdater(ApplicationDbContext context) : base(context)
        {
        }
    }
}