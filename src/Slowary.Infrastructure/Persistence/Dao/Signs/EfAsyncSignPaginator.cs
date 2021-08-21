using Slowary.Application.Common.Dao.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao.Signs
{
    public class EfAsyncSignPaginator : EfAsyncEntityPaginatorBase<Sign, ulong, ApplicationDbContext>, IAsyncSignPaginator
    {
        public EfAsyncSignPaginator(ApplicationDbContext context) : base(context)
        {
        }
    }
}