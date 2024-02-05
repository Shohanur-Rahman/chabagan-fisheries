namespace Chabagan.Fisheries.Entities.Mapping.Stock
{
    public class ProcessPurchase : VwBaseInfo
    {
        public string billNo { get; set; } = string.Empty;
        public DateTime? BillDate { get; set; }
        public long SupplierId { get; set; }
        public long ProjectId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DuesAmount { get; set; }
        public string? Note { get; set; }
        public bool ApprovalStatus { get; set; }
        public virtual List<ProcessPurchaseItem>? Items { get; set; }
    }
}
