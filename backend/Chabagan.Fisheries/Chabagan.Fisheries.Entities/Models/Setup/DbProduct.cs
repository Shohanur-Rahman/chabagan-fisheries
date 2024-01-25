using Chabagan.Chabagan.Fisheries;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Fisheries.Entities.Models.Setup
{
    public class DbProduct : BaseClassInfo
    {
        public string Name { get; set; } = string.Empty;
        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }
        public decimal MRP { get; set; }
        public string? Avatar { get; set; }
        public string? Description { get; set; }
        public DbStockCategory? Category { get; set; }
    }
}
