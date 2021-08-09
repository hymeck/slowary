using System;
using Slowary.Shared;

namespace Slowary.Data
{
    public class Word : IDateAdded, IDateUpdated, IDeleted
    {
        public uint WordId { get; set; }
        public string Value { get; set; }
        public string Explanation { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset Added { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
