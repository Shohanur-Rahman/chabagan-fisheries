using Chabagan.Fisheries.Entities.Models.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbSalesItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        [ForeignKey(nameof(Purchase))]
        public long PurchaseId { get; set; }
        [ForeignKey(nameof(Brand))]
        public long? BrandId { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public DbSales? Purchase { get; set; }
        public DbProduct? Product { get; set; }
        public DbBrand? Brand { get; set; }
    }
}
