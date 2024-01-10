using System.ComponentModel.DataAnnotations;

namespace Chabagan.Chabagan.Fisheries.Models.Fish
{
    public class DbFish : BaseClassInfo
    {
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public string? Description { get; set; }
    }
}
