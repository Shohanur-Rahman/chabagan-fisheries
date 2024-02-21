namespace Chabagan.Fisheries.Entities.Mapping.Stock
{
    public class ProcessPaymentCollection : VwBaseInfo
    {
        public DateTime? BillDate { get; set; }
        public long SupplierId { get; set; }
        public int PaymentCollectionType { get; set; }
        public decimal PaidAmount { get; set; }
        public string? Note { get; set; }
    }
}
