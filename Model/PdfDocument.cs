namespace DocCloud.Model
{
    public class PdfDocument
    {
        public List<PdfPage> Pages{get;}=new();
        public override string ToString()
        {
            return string.Join("\n", Pages);
        }
    }
}