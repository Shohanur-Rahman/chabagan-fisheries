using Chabagan.Chabagan.Fisheries;
using Chabagan.Fisheries.Entities.Models.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chabagan.Fisheries.Entities.Models.Stock
{
    public class DbExpense : BaseClassInfo
    {
        public DateTime? BillDate { get; set; }
        public decimal ExpenseAmount { get; set; }
        [ForeignKey(nameof(ExpenseType))]
        public long ExpenseTypeId { get; set; }
        public string? Note { get; set; }
        public virtual DbExpenseType? ExpenseType { get; set; }
    }
}
