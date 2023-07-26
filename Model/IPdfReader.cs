namespace DocCloud.Model;
public interface IPdfReader{
    PdfDocument ReadFromPath(string path);
}