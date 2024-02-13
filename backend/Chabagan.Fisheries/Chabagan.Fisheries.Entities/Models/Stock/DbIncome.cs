using Chabagan.Chabagan.Fisheries;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbIncome:BaseClassInfo
    {
        public DateTime? BillDate { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string? Note { get; set; }
    }
}
