﻿using Chabagan.Chabagan.Fisheries;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbPurchase:BaseClassInfo
    {
        public DateTime RegDate { get; set; }
        public long SupplierId { get; set; }
        public string? Location { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Dues { get; set; }
        public bool ApprovalStatus { get; set; }
    }
}
