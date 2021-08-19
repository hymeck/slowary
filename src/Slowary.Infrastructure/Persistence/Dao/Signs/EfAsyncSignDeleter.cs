using Slowary.Application.Common.Dao.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao.Signs
{
    public class EfAsyncSignDeleter : EfAsyncEntityDeleterBase<Sign, ulong, ApplicationDbContext>, IAsyncSignDeleter
    {
        public EfAsyncSignDeleter(ApplicationDbContext context) : base(context)
        {
        }
    }
}