using System;

namespace Slowary.Application.Responses.Signs
{
    public class SignResponse
    {
        public uint SignId { get; set; }
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
    }
}