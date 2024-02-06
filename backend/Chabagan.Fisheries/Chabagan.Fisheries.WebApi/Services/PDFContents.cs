using Chabagan.Fisheries.Entities.Models.Stock;

namespace Chabagan.Fisheries.WebApi.Services
{
    public class PDFContents
    {
        #region Purchase Invoice

        public static string GetPurchaseInvoice(DbPurchase info)
        {
            string htmlContent = string.Empty;

            string[] itemHeaders = { "SL.", "Item", "Brand", "QTY", "Price", "Discount", "Total" };

            htmlContent = $"<!doctype html><html><head><meta charset='utf-8'><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/></head><body>" +
                $"<table width='100%' border='0' cellpadding='0' cellspacing='0' align='center'>" +
                $"{GetSingleColumRow(info.Supplier?.ShopName, "30px", "h1")}" +
                $"{GetSingleColumRow(info.Supplier?.Name + ", " + info.Project?.Name + ", " + info.Supplier?.Mobile, "16px", "p")}" +
                $"</table>" +
                $"<table width='100%' border='0' cellpadding='0' cellspacing='0' align='center' style='margin-top: 20px;'><thead>" +
                 $"{GetHeaderRowFromArray(itemHeaders,"14px")}</thead>" +
                 $"<tbody>" +
                 $"" + GetItemsRow(info.Items.ToList()) + 
                 $"" + GetColSpanRowByTextAndValue(6,1,"Total Price", String.Format("{0:0.00}", info.TotalAmount), "16px") + 
                 $"" + GetColSpanRowByTextAndValue(6,1,"Less Amount", String.Format("{0:0.00}", info.Discount), "16px") + 
                 $"" + GetColSpanRowByTextAndValue(6,1,"Actual Amount", String.Format("{0:0.00}", info.NetAmount), "16px", 700) + 
                 $"" + GetColSpanRowByTextAndValue(6,1,"Paid", String.Format("{0:0.00}", info.PaidAmount), "16px", 700) + 
                 $"" + GetColSpanRowByTextAndValue(6,1,"Dues", String.Format("{0:0.00}", info.DuesAmount), "16px", 700) + 
                 $"</tbody></table>" +
                $"</body></html>";

            return htmlContent;
        }

        public static string GetItemsRow(List<DbPurchaseItem> items)
        {
            string rowString = string.Empty;

            int counter = 1;
            foreach (DbPurchaseItem item in items)
            {
                string[] itemInfo = { counter.ToString(), item.Product?.Name, item.Brand.Name, String.Format("{0:0.00}", item.Qty), String.Format("{0:0.00}", item.Rate), String.Format("{0:0.00}", item.Discount), String.Format("{0:0.00}", item.TotalPrice) };

                rowString = rowString + GetRowFromArray(itemInfo, "16px");
                counter++;
            }

            return rowString;
        }

        #endregion

        #region Private Methods

        private static string GetSingleColumRow(string text, string fontSize, string innerElement)
        {
            return $"<tr> " +
                $"<td> <{innerElement} style='display: block; text-transform: uppercase; text-align: center; font-size: {fontSize}; font-family: 'Open Sans', sans-serif;'>{text}</{innerElement}></td>" +
                $"</tr>";
        }

        private static string GetHeaderRowFromArray(string[] strings, string fontSize)
        {
            string row = $"<tr style=''>";

            foreach (var item in strings)
            {
                row = row + $"<th style='border-top: 2px solid #ddd; border-bottom: 2px solid #ddd;padding-top: 10px; padding-bottom: 10px; text-transform: uppercase; text-align: center; font-size: {fontSize}; font-family: 'Open Sans', sans-serif;'> {item} </th>";
            }
            row = row + $"</tr>";

            return row ;
        }

        private static string GetRowFromArray(string[] strings, string fontSize)
        {
            string row = $"<tr>";

            foreach (var item in strings)
            {
                row = row + $"<td style='border-bottom: 1px solid #ddd;padding-top: 5px; padding-bottom: 5px; text-transform: uppercase; text-align: center; font-size: {fontSize}; font-family: 'Open Sans', sans-serif;'> {item} </td>";
            }
            row = row + $"</tr>";

            return row;
        }

        private static string GetColSpanRowByTextAndValue(int colSpan1, int colspan2, string label, string value, string fontSize, int fontWeight = 300)
        {
            string row = $"<tr>";
            row = row + $"<td colspan='{colSpan1}' style='padding-top: 8px; padding-bottom: 8px; text-transform: uppercase; text-align: right; font-weight: {fontWeight}; font-size: {fontSize}; font-family: 'Open Sans', sans-serif;'> {label} </td>";
            row = row + $"<td colspan='{colspan2}' style='padding-top: 8px; padding-bottom: 8px; text-transform: uppercase; text-align: center; font-weight: {fontWeight}; font-size: {fontSize}; font-family: 'Open Sans', sans-serif;'> {value} </td>";
            row = row + $"</tr>";

            return row;
        }

        #endregion
    }
}
