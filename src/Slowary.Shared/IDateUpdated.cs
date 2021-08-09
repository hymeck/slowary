using System;

namespace Slowary.Shared
{
    public interface IDateUpdated
    {
        public DateTimeOffset Updated { get; set; }
    }
}
