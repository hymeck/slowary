using MediatR;

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
}