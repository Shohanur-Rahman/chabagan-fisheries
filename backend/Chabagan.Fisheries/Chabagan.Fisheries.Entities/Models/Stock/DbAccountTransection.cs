using Chabagan.Chabagan.Fisheries;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbAccountTransection:BaseClassInfo
    {
        public DateTime? BillDate { get; set; }
        public long SupplierId { get; set; }
        public long ProjectId { get; set; }
        public int TransTypeId { get; set; }
        public long BillId { get; set; }
        public decimal SalesTotalAmount { get; set; }
        public decimal SalesDiscount { get; set; }
        public decimal SalesNetAmount { get; set; }
        public decimal SalesPaidAmount { get; set; }
        public decimal SalesDuesAmount { get; set; }

        public decimal SalesReturnTotalAmount { get; set; }
        public decimal SalesReturnDiscount { get; set; }
        public decimal SalesReturnNetAmount { get; set; }
        public decimal SalesReturnPaidAmount { get; set; }
        public decimal SalesReturnDuesAmount { get; set; }

        public decimal PurchaseTotalAmount { get; set; }
        public decimal PurchaseDiscount { get; set; }
        public decimal PurchaseNetAmount { get; set; }
        public decimal PurchasePaidAmount { get; set; }
        public decimal PurchaseDuesAmount { get; set; }

        public decimal PurchaseReturnTotalAmount { get; set; }
        public decimal PurchaseReturnDiscount { get; set; }
        public decimal PurchaseReturnNetAmount { get; set; }
        public decimal PurchaseReturnPaidAmount { get; set; }
        public decimal PurchaseReturnDuesAmount { get; set; }
        public bool ApprovalStatus { get; set; }
    }
}
