using Chabagan.Chabagan.Fisheries;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbProduct : BaseClassInfo
    {
        public string Name { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public decimal MRP { get; set; }
        public string? Avatar { get; set; }
        public string? Description { get; set; }
    }
}
