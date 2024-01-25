using Microsoft.AspNetCore.Http;

namespace Chabagan.Fisheries.Entities.Mapping.Setup
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
