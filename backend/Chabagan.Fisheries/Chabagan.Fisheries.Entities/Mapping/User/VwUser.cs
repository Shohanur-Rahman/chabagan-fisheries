using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Chabagan.Fisheries.Mapping.User
{
    public class VwUser
    {     
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        [StringLength(15)] 
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? Attachment { get; set; }
    }
}
