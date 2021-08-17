using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slowary.Domain.Entities
{
    /// <summary>
    /// Represents sign (in semiotic sense) of any complexity. 
    /// </summary>
    [Table("sign")]
    public class Sign : IUintEntity
    {
        /// <summary>
        /// Gets or sets sign id.
        /// </summary>
        [Key]
        [Column("sign_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets sign value.
        /// </summary>
        /// <example>Value of "Dog" (word),
        /// "Zed is dead" (expression),
        /// "Given enough eyeballs, all bugs are shallow." (quote), etc.</example>
        [Column("value")]
        [Required]
        [StringLength(255)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets sign meaning.
        /// </summary>
        [Column("semantics")]
        [StringLength(255)]
        public string Semantics { get; set; }

        /// <summary>
        /// Gets or sets bright example of sign usage.
        /// </summary>
        [Column("example")]
        [StringLength(255)]
        public string Example { get; set; }

        /// <summary>
        /// Gets or sets place where sign was found.
        /// </summary>
        [Column("source")]
        [StringLength(255)]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets optional additional information connected with sign.
        /// </summary>
        [Column("note")]
        [StringLength(255)]
        public string Note { get; set; }
    }
}