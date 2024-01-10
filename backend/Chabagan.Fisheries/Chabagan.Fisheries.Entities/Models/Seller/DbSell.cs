using Chabagan.Chabagan.Fisheries.Models.Area;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chabagan.Chabagan.Fisheries.Models.Seller
{
    public class DbSell : BaseClassInfo
    {

        [StringLength(500)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? GarirName { get; set; }

        public decimal TotalSellInKG { get; set; }

        public DateTime SellDate { get; set; }

        public long SellerId { get; set; }
        public decimal TotalSellPrice { get; set; }
        public string? SellNote { get; set; }

        [ForeignKey(nameof(Area))]
        public long AreaId { get; set; }
        public virtual DbArea? Area { get; set; }
        public long ProjectId { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountDue { get; set; }
        public bool IsClosedByAdmin { get; set; }
        public virtual ICollection<DbSellItem>? SalesItems { get; set; }

    }
}
