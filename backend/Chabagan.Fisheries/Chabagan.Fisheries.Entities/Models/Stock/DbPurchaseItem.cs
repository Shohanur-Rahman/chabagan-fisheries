using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbPurchaseItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Product))]
        public long ProductID { get; set; }
        [ForeignKey(nameof(Purchase))]
        public long PurchaseId { get; set; }
        public string? Brand { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string? ProdSlNo { get; set; }
        public DbPurchase? Purchase { get; set; }
        public DbProduct? Product { get; set; }
    }
}
