using Chabagan.Chabagan.Fisheries;
using Chabagan.Fisheries.Entities.Models.Setup;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    [Index(nameof(BillNo), IsUnique = true)]
    public class DbPurchaseReturn : BaseClassInfo
    {
        public string BillNo { get; set; } = string.Empty;
        public DateTime? BillDate { get; set; }
        [ForeignKey(nameof(Supplier))]
        public long SupplierId { get; set; }
        [ForeignKey(nameof(Project))]
        public long ProjectId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DuesAmount { get; set; }
        public string? Note { get; set; }
        public bool ApprovalStatus { get; set; }
        public virtual DbSupplier? Supplier { get; set; }
        public virtual DbProject? Project { get; set; }
        public virtual ICollection<DbPurchaseReturnItem>? Items { get; set; }
    }
}
