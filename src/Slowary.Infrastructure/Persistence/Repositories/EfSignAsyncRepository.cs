using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.SomeHelp;
using Slowary.Application.Common.Contexts;
using Slowary.Application.Common.Repositories;
using Slowary.Domain.Entities;

namespace Slowary.Infrastructure.Persistence.Repositories
{
    public class EfSignAsyncRepository : ISignAsyncRepository
    {
        private readonly IApplicationDbContext _context;

        public EfSignAsyncRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sign> AddAsync(Sign entity, CancellationToken token = default)
        {
            _context.Context.Set<Sign>().Add(entity);
            await _context.SaveChangesAsync(token);
            return entity;
        }

        public async Task<Option<Sign>> FindAsync(ulong id, CancellationToken token = default)
        {
            var entity = await _context.Context.Set<Sign>().FindAsync(new object[]{id}, token);
            return entity?.ToSome() ?? Option<Sign>.None;
        }
    }
}