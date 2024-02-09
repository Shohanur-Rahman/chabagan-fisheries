using iText.Kernel.Pdf;
using iText.Layout;
using iText.Html2pdf;

namespace Chabagan.Fisheries.WebApi.Services
{
    public class PdfService
    {
        
        public static byte[] GeneratePdf(string htmlContent)
        {
            byte[] pdfBytes;
            using (MemoryStream outputStream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(outputStream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                HtmlConverter.ConvertToPdf(htmlContent, pdf, new ConverterProperties());

                document.Close();
                pdfBytes = outputStream.ToArray();
            }
            return pdfBytes;
        }
    }
}
