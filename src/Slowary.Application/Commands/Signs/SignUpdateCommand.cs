using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Slowary.Application.Common.Repositories;
using Slowary.Domain.Entities;

namespace Slowary.Application.Commands.Signs
{
    public class SignUpdateCommand : IRequest
    {
        public ulong SignId { get; set; }
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
    }
    
    public class SignUpdateCommandHandler : IRequestHandler<SignUpdateCommand>
    {
        private readonly ISignAsyncRepository _repository;
        private readonly IMapper _mapper;
    
        public SignUpdateCommandHandler(ISignAsyncRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(SignUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SignUpdateCommand, Sign>(request);
            await _repository.UpdateAsync(entity, cancellationToken);
            return Unit.Value;
        }
    }
}