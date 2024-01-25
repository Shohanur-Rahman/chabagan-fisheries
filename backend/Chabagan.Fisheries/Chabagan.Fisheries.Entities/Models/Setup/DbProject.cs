using System.ComponentModel.DataAnnotations;
using Chabagan.Chabagan.Fisheries;

namespace Chabagan.Fisheries.Entities.Models.Setup
{
    public class DbProject : BaseClassInfo
    {
        [Required]
        [StringLength(500)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        public string Union { get; set; } = string.Empty;
        public int WordNumber { get; set; }
        public string? Avatar { get; set; }

    }
}
