using System.ComponentModel.DataAnnotations;

namespace Chabagan.Chabagan.Fisheries.Models.Area
{
    public class DbArea : BaseClassInfo
    {
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        public string Union { get; set; } = string.Empty;
        public int WordNumber { get; set; }
        public string? Avatar { get; set; }
    }
}
