namespace DocCloud.Model;
public class TextOnlyPageContent : PdfPageContent
{
    public string Text{get;}
    public override string ToString()
    {
        return Text;
    }
    public TextOnlyPageContent(string text)
    {
        Text=text;
    }
}