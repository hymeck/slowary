using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Slowary.Application.Common.Dao.Signs;
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
        private readonly IAsyncSignAdder _adder;
        private readonly IMapper _mapper;

        public SignCreateCommandHandler(IAsyncSignAdder adder, IMapper mapper)
        {
            _adder = adder;
            _mapper = mapper;
        }

        public async Task<SignResponse> Handle(SignCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SignCreateCommand, Sign>(request);
            await _adder.AddAsync(entity, cancellationToken);
            return _mapper.Map<Sign, SignResponse>(entity);
        }
    }
}