namespace Chabagan.Fisheries.Mapping.Area
{
    public class VwSellItem
    {
        public long Id { get; set; }
        public long SellId { get; set; }
        public decimal TotalKG { get; set; }
        public int PiecesPerKG { get; set; }
        public int TotalPieces { get; set; }
        public decimal PricePerKG { get; set; }
        public decimal Price { get; set; }
        public long FishId { get; set; }

    }
}
