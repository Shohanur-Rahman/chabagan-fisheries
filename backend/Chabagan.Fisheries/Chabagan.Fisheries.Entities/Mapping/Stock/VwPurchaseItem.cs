namespace Chabagan.Fisheries.Entities.Mapping.Stock
{
    public class VwPurchaseItem
    {
        public long Id { get; set; }
        public long ProductID { get; set; }
        public long PurchaseId { get; set; }
        public string? Brand { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string? ProdSlNo { get; set; }
    }
}
