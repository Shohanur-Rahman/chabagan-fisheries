using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chabagan.Fisheries.Entities.Mapping.Visualization
{
    public class TransectionSummary
    {
        public long Id { get; set; }
        public string? Supplier { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal PurchaseReturnAmount { get; set; }
        public decimal PurchaseDues { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal SalesReturnAmount { get; set; }
        public decimal SalesDues { get; set; }
        public decimal Balance { get; set; }

        public TransectionSummary()
        {
            
        }

        public TransectionSummary(DataRow objectRow)
        {
            this.Id = Convert.ToInt64(objectRow["Id"].ToString());
            this.Supplier = objectRow["Supplier"].ToString();
            this.PurchaseAmount = Convert.ToDecimal(objectRow["PurchaseAmount"].ToString());
            this.PurchaseReturnAmount = Convert.ToDecimal(objectRow["PurchaseReturnAmount"].ToString());
            this.PurchaseDues = Convert.ToDecimal(objectRow["PurchaseDues"].ToString());
            this.SalesAmount = Convert.ToDecimal(objectRow["SalesAmount"].ToString());
            this.SalesReturnAmount = Convert.ToDecimal(objectRow["SalesReturnAmount"].ToString());
            this.SalesDues = Convert.ToDecimal(objectRow["SalesDues"].ToString());
            this.Balance = Convert.ToDecimal(objectRow["Balance"].ToString());
        }
    }
}
