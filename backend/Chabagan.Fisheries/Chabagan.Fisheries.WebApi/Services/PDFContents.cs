using Chabagan.Fisheries.Entities.Models.Stock;

namespace Chabagan.Fisheries.WebApi.Services
{
    public class PDFContents
    {
        #region Purchase Invoice

        public static string GetPurchaseInvoice(DbPurchase info)
        {
            string htmlContent = string.Empty;

            htmlContent = $"<html><body>" +
                $"<table width='100%' border='0' cellpadding='0' cellspacing='0' align='center' class='fullTable table table-bordered'>" +
                $"{GetSingleColumRow(info.Supplier?.ShopName, "30px", "h1")}" +
                $"{GetSingleColumRow(info.Supplier?.Name + "," + info.Project?.Name + "," + info.Supplier?.Mobile, "16px", "p")}" +
                $"</table>" +
                $"</body></html>";

            return htmlContent;
        }

        #endregion

        #region Private Methods

        private static string GetSingleColumRow(string text, string fontSize, string innerElement)
        {
            return $"<tr> " +
                $"<td> <{innerElement} style='display: block; text-transform: uppercase; text-align: center; font-size: {fontSize}; font-family: 'Open Sans', sans-serif;'>{text}</{innerElement}></td>" +
                $"</tr>";
        }

        #endregion
    }
}
