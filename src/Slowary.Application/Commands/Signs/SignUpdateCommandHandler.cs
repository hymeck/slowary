using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Slowary.Application.Common.Dao.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Application.Commands.Signs
{
    public class SignUpdateCommandHandler : IRequestHandler<SignUpdateCommand>
    {
        private readonly IAsyncSignUpdater _updater;
        private readonly IMapper _mapper;
    
        public SignUpdateCommandHandler(IAsyncSignUpdater updater, IMapper mapper)
        {
            _updater = updater;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(SignUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SignUpdateCommand, Sign>(request);
            await _updater.UpdateAsync(entity, cancellationToken);
            return Unit.Value;
        }
    }
}