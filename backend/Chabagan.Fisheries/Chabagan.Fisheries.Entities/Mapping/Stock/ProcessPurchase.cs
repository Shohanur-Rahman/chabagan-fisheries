namespace Chabagan.Fisheries.Entities.Mapping.Stock
{
    public class ProcessPurchase : VwBaseInfo
    {
        public string billNo { get; set; } = string.Empty;
        public DateTime? BillDate { get; set; }
        public long SupplierId { get; set; }
        public int TypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DuesAmount { get; set; }
    }
}
