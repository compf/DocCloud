namespace DocCloud.Model.PdfPig;
using Pig=global::UglyToad.PdfPig;
public class PdfPigReader : IPdfReader
{
    public PdfDocument ReadFromPath(string path)
    {
        Console.WriteLine("Start reading pdf");
         PdfDocument doc=new PdfDocument();
        using (global::UglyToad.PdfPig.PdfDocument document = Pig.PdfDocument.Open(path))
        {
           
            for (var i = 0; i < document.NumberOfPages; i++)
            {
                // This starts at 1 rather than 0.
                var page = document.GetPage(i + 1);
                
    
                
             var pdfPage=new PdfPage(i+1,new TextOnlyPageContent(page.Text));
             doc.Pages.Add(pdfPage);
            }
        }
        return doc;
    }
}