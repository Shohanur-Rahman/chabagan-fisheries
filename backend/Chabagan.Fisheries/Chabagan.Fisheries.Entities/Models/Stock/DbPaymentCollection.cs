using Chabagan.Chabagan.Fisheries;
using Chabagan.Fisheries.Entities.Models.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbPaymentCollection : BaseClassInfo
    {
        public DateTime? BillDate { get; set; }
        [ForeignKey(nameof(Supplier))]
        public long SupplierId { get; set; }
        public decimal PaidAmount { get; set; }
        public string? Note { get; set; }
        public virtual DbSupplier? Supplier { get; set; }
    }
}
