using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Chabagan.Fisheries.Models.Project
{

    public class VwProject 
    {
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        public int AreaId { get; set; }
        public IFormFile? Attachment { get; set; }
        public string? Avatar { get; set; }
    }
}
