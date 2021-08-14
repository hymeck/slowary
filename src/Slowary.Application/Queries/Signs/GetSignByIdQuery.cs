using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Slowary.Application.Common.Contexts;
using Slowary.Application.Responses.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Application.Queries.Signs
{
    public class GetSignByIdQuery : IRequest<SignResponse>
    {
        public uint Id { get; }

        public GetSignByIdQuery(uint id)
        {
            Id = id;
        }
    }

    public class GetSignByIdQueryHandler : IRequestHandler<GetSignByIdQuery, SignResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetSignByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SignResponse> Handle(GetSignByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Context.Set<Sign>().FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                return null;
            
            return new SignResponse
            {
                SignId = entity.Id,
                Example = entity.Example ?? string.Empty,
                Note = entity.Note ?? string.Empty,
                Semantics = entity.Semantics,
                Source = entity.Source ?? string.Empty,
                Value = entity.Value
            };
        }
    }
}