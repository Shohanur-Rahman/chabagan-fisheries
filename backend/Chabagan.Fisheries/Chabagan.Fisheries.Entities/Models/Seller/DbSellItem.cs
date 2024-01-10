using Chabagan.Chabagan.Fisheries.Models.Fish;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chabagan.Chabagan.Fisheries.Models.Seller
{
    public class DbSellItem
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SellId { get; set; }
        public decimal TotalKG { get; set; }
        public int PiecesPerKG { get; set; }
        public int TotalPieces { get; set; }
        public decimal PricePerKG { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(Fish))]
        public long FishId { get; set; }
        public virtual DbFish? Fish { get; set; }

    }
}
