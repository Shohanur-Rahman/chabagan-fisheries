namespace Chabagan.Fisheries.Entities.Mapping.Stock
{
    public class PaymentCollectionGrid : VwBaseInfo
    {
        public string? BillDate { get; set; }
        public long? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public decimal? PaidAmount { get; set; }
        public string? Note { get; set; }
    }
}
