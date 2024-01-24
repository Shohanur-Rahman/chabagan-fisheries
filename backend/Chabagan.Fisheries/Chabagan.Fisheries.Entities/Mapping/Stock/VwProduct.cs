using Chabagan.Fisheries.Models.Category;
using Microsoft.AspNetCore.Http;

namespace Chabagan.Fisheries.Entities.Mapping.Stock
{
    public class VwProduct : VwBaseInfo
    {
        public string Name { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public decimal MRP { get; set; }
        public string? Avatar { get; set; }
        public string? Description { get; set; }
        public IFormFile? Attachment { get; set; }
        public VwStockCategory? Category { get; set; }
    }
}
