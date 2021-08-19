namespace Slowary.Domain.Entities
{
    /// <summary>
    /// Represents sign (in semiotic sense) of any complexity.
    /// </summary>
    public class Sign : IDefaultEntity
    {
        public ulong Id { get; set; }
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
        public ulong AuditDetailId { get; set; }
        public SignAuditDetail AuditDetail { get; set; }
    }
}