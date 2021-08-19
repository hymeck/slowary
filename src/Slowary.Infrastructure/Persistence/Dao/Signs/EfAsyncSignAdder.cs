using Slowary.Application.Common.Dao.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Dao.Signs
{
    public class EfAsyncSignAdder : EfAsyncEntityAdderBase<Sign, ulong, ApplicationDbContext>, IAsyncSignAdder
    {
        public EfAsyncSignAdder(ApplicationDbContext context) : base(context)
        {
        }
    }
}