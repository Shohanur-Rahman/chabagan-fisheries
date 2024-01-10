using System.ComponentModel.DataAnnotations;

namespace Chabagan.Fisheries.Mapping.Area
{
    public class VwSell
    {
        public long Id { get; set; }
        [StringLength(500)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? GarirName { get; set; }

        public decimal TotalSellInKG { get; set; }

        public DateTime SellDate { get; set; }

        public long SellerId { get; set; }

        public decimal TotalSellPrice { get; set; }

        public string? SellNote { get; set; }

        public long AreaId { get; set; }
        public long ProjectId { get; set; }

        public decimal AmountPaid { get; set; }
        public decimal AmountDue { get; set; }
        public bool IsClosedByAdmin { get; set; }
        public List<VwSellItem>? SellItems { get; set; }

    }
}