using Slowary.Application.Common.Dao.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao.Signs
{
    public class EfAsyncSignFinder : EfAsyncEntityFinderBase<Sign, ulong, ApplicationDbContext>, IAsyncSignFinder
    {
        public EfAsyncSignFinder(ApplicationDbContext context) : base(context)
        {
        }
    }
}