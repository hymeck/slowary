using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt;
using MediatR;
using Slowary.Application.Common.Dao.Signs;
using Slowary.Application.Responses.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Application.Queries.Signs
{
    public class GetSignByIdQuery : IRequest<Option<SignResponse>>
    {
        public ulong Id { get; }

        public GetSignByIdQuery(ulong id)
        {
            Id = id;
        }
    }

    public class GetSignByIdQueryHandler : IRequestHandler<GetSignByIdQuery, Option<SignResponse>>
    {
        private readonly IAsyncSignFinder _finder;
        private readonly IMapper _mapper;

        public GetSignByIdQueryHandler(IAsyncSignFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<Option<SignResponse>> Handle(GetSignByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _finder.FindAsync(request.Id, cancellationToken);
            return entity.Match(e => _mapper.Map<Sign, SignResponse>(e), Option<SignResponse>.None);
        }
    }
}