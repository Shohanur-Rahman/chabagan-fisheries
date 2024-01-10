using Chabagan.Fisheries.Models.Feed;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Chabagan.Fisheries.Models.Category
{
    public class VwCategory
    {
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        public int FeedId { get; set; }
        public virtual VwFeed? Feed { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? Attachment { get; set; }
        public string? Description { get; set; }
    }
}
