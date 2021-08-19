using MediatR;

namespace Slowary.Application.Commands.Signs
{
    public class SignDeleteCommand :IRequest<bool>
    {
        public ulong SignId { get; }

        public SignDeleteCommand(ulong signId)
        {
            SignId = signId;
        }
    }
}