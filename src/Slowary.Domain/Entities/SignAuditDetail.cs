using System;

namespace Slowary.Domain.Entities
{
    public class SignAuditDetail : IEntity<ulong>
    {
        public ulong Id { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
        public ulong SignId { get; set; }
        public Sign Sign { get; set; }
    }
}