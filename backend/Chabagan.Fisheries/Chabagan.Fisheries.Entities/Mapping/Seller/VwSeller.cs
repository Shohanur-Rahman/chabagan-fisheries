﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Chabagan.Fisheries.Models.Seller
{
    public class VwSeller
    {
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? Attachment { get; set; }
        public string? Description { get; set; }
    }
}
