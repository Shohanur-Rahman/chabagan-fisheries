using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Chabagan.Chabagan.Fisheries.Models.Feed;

namespace Chabagan.Chabagan.Fisheries.Models.Category
{
    public class DbCategory : BaseClassInfo
    {
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(FeedId))]
        public int FeedId { get; set; }
        public virtual DbFeed? Feed { get; set; }
        public string? Avatar { get; set; }
        public string? Description { get; set; }
    }
}
