using Chabagan.Fisheries.Entities.Models.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chabagan.Fisheries.Entities.Mapping.User
{
    public class VwUserResponse
    {
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        [StringLength(15)]
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? Attachment { get; set; }
        public DbRole? Role { get; set; }
    }
}
