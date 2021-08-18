namespace Slowary.Domain.Entities
{
    /// <summary>
    /// Represents sign (in semiotic sense) of any complexity.
    /// </summary>
    public class Sign : IDefaultEntity
    {
        public ulong Id { get; set; }

        /// <example>Value of "Dog" (word),
        /// "Zed is dead" (expression),
        /// "Given enough eyeballs, all bugs are shallow." (quote), etc.</example>
        public string Value { get; set; }
        public string Semantics { get; set; }
        public string Example { get; set; }
        public string Source { get; set; }
        public string Note { get; set; }
    }
}