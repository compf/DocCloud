namespace DocCloud.Model;
public struct PdfPage{
    public int PageNr{get;}
    public PdfPageContent Content{get;}
    public PdfPage(int page,PdfPageContent content)
    {
        PageNr=page;
        Content=content;
    }
    public override string ToString()
    {
        return Content.ToString();
    }
}