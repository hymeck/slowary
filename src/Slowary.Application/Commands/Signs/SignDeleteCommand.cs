using LanguageExt;
using MediatR;
using Slowary.Application.Responses.Signs;

namespace Slowary.Application.Commands.Signs
{
    public class SignDeleteCommand :IRequest<Option<SignResponse>>
    {
        public ulong SignId { get; }

        public SignDeleteCommand(ulong signId)
        {
            SignId = signId;
        }
    }
}