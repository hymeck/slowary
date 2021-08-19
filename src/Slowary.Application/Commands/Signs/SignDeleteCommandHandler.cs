using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt;
using MediatR;
using Slowary.Application.Common.Dao.Signs;
using Slowary.Application.Responses.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Application.Commands.Signs
{
    public class SignDeleteCommandHandler : IRequestHandler<SignDeleteCommand, Option<SignResponse>>
    {
        private readonly IAsyncSignDeleter _deleter;
        private readonly IMapper _mapper;

        public SignDeleteCommandHandler(IAsyncSignDeleter deleter, IMapper mapper)
        {
            _deleter = deleter;
            _mapper = mapper;
        }

        public async Task<Option<SignResponse>> Handle(SignDeleteCommand request, CancellationToken cancellationToken)
        {
            var option = await _deleter.DeleteAsync(new Sign {Id = request.SignId}, cancellationToken);
            return option.Match(e => _mapper.Map<Sign, SignResponse>(e), Option<SignResponse>.None);
        }
    }
}