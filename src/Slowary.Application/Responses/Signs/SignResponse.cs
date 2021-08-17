using Slowary.Application.Common.Mappings;
using Slowary.Domain.Entities;

namespace Slowary.Application.Responses.Signs
{
    // public class SignResponse : IMapFrom<Sign>
    public class SignResponse
    {
        public ulong SignId { get; set; }
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
    }
}