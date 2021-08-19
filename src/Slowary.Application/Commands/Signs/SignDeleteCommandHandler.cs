using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Slowary.Application.Common.Repositories;
using Slowary.Domain.Entities;

namespace Slowary.Application.Commands.Signs
{
    public class SignDeleteCommandHandler : IRequestHandler<SignDeleteCommand, bool>
    {
        private readonly ISignAsyncRepository _repository;
        private readonly IMapper _mapper;

        public SignDeleteCommandHandler(ISignAsyncRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SignDeleteCommand request, CancellationToken cancellationToken)
        {
            var hasDeleted = await _repository.DeleteAsync(new Sign {Id = request.SignId}, cancellationToken);
            return hasDeleted;
        }
    }
}