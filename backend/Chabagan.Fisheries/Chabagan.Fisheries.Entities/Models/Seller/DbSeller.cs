using System.ComponentModel.DataAnnotations;

namespace Chabagan.Chabagan.Fisheries.Models.Seller
{
    public class DbSeller : BaseClassInfo
    {
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Avatar { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<DbSell>? Sales { get; set; }
    }
}
