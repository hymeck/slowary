using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Slowary.Application.Common.Contexts;
using Slowary.Application.Responses.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Application.Commands.Signs
{
    public class SignCreateCommand : IRequest<SignResponse>
    {
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
    }

    public class SignCreateCommandHandler : IRequestHandler<SignCreateCommand, SignResponse>
    {
        private readonly IApplicationDbContext _context;

        public SignCreateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SignResponse> Handle(SignCreateCommand request, CancellationToken cancellationToken)
        {
            // todo: replace this horror by repository and mapper?

            var entity = new Sign
            {
                Example = request.Example,
                Note = request.Note,
                Semantics = request.Semantics,
                Source = request.Source,
                Value = request.Value
            };

            _context.Context.Set<Sign>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

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