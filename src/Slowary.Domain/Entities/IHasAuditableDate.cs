using System;

namespace Slowary.Domain.Entities
{
    public interface IHasAuditableDate
    {
        public DateTime? Added { get; set; }
        public DateTime? Modified { get; set; }
    }
}