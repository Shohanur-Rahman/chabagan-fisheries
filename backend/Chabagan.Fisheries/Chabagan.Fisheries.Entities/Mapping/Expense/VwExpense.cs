using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Chabagan.Fisheries.Models.Expense
{
    public class VwExpense
    {
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "Value should be at least three character")]
        public string CostName { get; set; } = string.Empty;
        public IFormFile? Attachment { get; set; }
        public string? Avatar { get; set; }

        public string? Description { get; set; }
    }
}
