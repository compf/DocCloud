namespace DocCloud.Model.PdfPig;
using System.Text.RegularExpressions;
using Pig = global::UglyToad.PdfPig;
public class PdfPigReader : IPdfReader
{
    public PdfDocument ReadFromPath(string path)
    {
        Console.WriteLine("Start reading pdf");
        PdfDocument doc = new PdfDocument();
        using (global::UglyToad.PdfPig.PdfDocument document = Pig.PdfDocument.Open(path))
        {

            for (var i = 0; i < document.NumberOfPages; i++)
            {
                // This starts at 1 rather than 0.
                var page = document.GetPage(i + 1);

                string text = page.Text;
                text = OptimizeText(text);

                var pdfPage = new PdfPage(i + 1, new TextOnlyPageContent(text));
                Console.WriteLine(text);
                throw new Exception("cool");
                doc.Pages.Add(pdfPage);
            }
        }
        return doc;
    }
    private string OptimizeText(string text)
    {
        List<string> result = new();
        string buffer = "";
        for (int i = 0; i < text.Length; i++)
        {
            char prev = (i > 0 ? text[i - 1] : '\0');
            char curr = text[i];
            char next = (i < text.Length - 1 ? text[i + 1] : '\0');

            if (curr == '-')
            {

            }
            else if (Char.IsDigit(curr) && Char.IsLetter(next) || Char.IsLetter(curr) && Char.IsDigit(next)

            || Char.IsLower(curr) && Char.IsUpper(next)
            )
            {
                buffer += curr;
                result.Add(buffer);
                buffer = "";

            }
            else if (curr == ' ' || curr == ',' || curr == '.' || curr == '(' || curr == ')')
            {
                result.Add(buffer);
                buffer = "";
            }
            else
            {
                buffer += curr;
            }
        }
        result.Add(buffer);
        return string.Join(" ", result);
    }
}