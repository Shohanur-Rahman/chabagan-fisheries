namespace Chabagan.Fisheries.Entities.Mapping.Stock
{
    public class ProcessPurchaseItem
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long PurchaseId { get; set; }
        public long? BrandId { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
