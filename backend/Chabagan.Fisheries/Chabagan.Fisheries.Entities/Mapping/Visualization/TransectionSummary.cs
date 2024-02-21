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
        public decimal PurchasePaidAmount { get; set; }
        public decimal PurchaseDues { get; set; }
        public decimal PurchaseReturnAmount { get; set; }
        public decimal PurchaseReturnPaidAmount { get; set; }
        public decimal PurchaseReturnDues { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal SalesPaidAmount { get; set; }
        public decimal SalesDues { get; set; }
        public decimal SalesReturnAmount { get; set; }
        public decimal SalesReturnPaidAmount { get; set; }
        public decimal SalesReturnDues { get; set; }
        public decimal Balance { get; set; }

        public TransectionSummary()
        {
            
        }

        public TransectionSummary(DataRow objectRow)
        {
            this.Id = Convert.ToInt64(objectRow["Id"].ToString());
            this.Supplier = objectRow["Supplier"].ToString();
            this.PurchaseAmount = Convert.ToDecimal(objectRow["PurchaseAmount"].ToString());
            this.PurchasePaidAmount = Convert.ToDecimal(objectRow["PurchasePaidAmount"].ToString());
            this.PurchaseDues = Convert.ToDecimal(objectRow["PurchaseDues"].ToString());
            this.PurchaseReturnAmount = Convert.ToDecimal(objectRow["PurchaseReturnAmount"].ToString());
            this.PurchaseReturnPaidAmount = Convert.ToDecimal(objectRow["PurchaseReturnPaidAmount"].ToString());
            this.PurchaseReturnDues = Convert.ToDecimal(objectRow["PurchaseReturnDues"].ToString());
            this.SalesAmount = Convert.ToDecimal(objectRow["SalesAmount"].ToString());
            this.SalesPaidAmount = Convert.ToDecimal(objectRow["SalesPaidAmount"].ToString());
            this.SalesDues = Convert.ToDecimal(objectRow["SalesDues"].ToString());
            this.SalesReturnAmount = Convert.ToDecimal(objectRow["SalesReturnAmount"].ToString());
            this.SalesReturnPaidAmount = Convert.ToDecimal(objectRow["SalesReturnPaidAmount"].ToString());
            this.SalesReturnDues = Convert.ToDecimal(objectRow["SalesReturnDues"].ToString());
            this.Balance = Convert.ToDecimal(objectRow["Balance"].ToString());
        }
    }
}
