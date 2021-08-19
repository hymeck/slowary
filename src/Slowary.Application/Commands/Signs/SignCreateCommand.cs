using MediatR;
using Slowary.Application.Responses.Signs;

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
}