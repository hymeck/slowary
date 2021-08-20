using System;

namespace Slowary.Application.Responses.Signs
{
    public class SignResponse
    {
        public ulong SignId { get; set; }
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
    }
}