using Slowary.Application.Common.Repositories;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Repositories
{
    public class EfSignAsyncRepository : AbstractEfRepository<Sign, ulong, ApplicationDbContext>, ISignAsyncRepository
    {
        public EfSignAsyncRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}