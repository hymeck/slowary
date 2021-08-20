using System;

namespace Slowary.Domain.Entities
{
    /// <summary>
    /// Represents sign (in semiotic sense) of any complexity.
    /// </summary>
    public class Sign : IDefaultEntity, IHasAuditableDate
    {
        public ulong Id { get; set; }
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
        public DateTime? Added { get; set; }
        public DateTime? Modified { get; set; }
    }
}