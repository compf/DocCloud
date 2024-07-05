#if PLAYGROUND
namespace DoccCloud;

using DocCloud.Model.PdfPig;
using DocCloud.Model.TextProcessing;
using UglyToad.PdfPig.Fonts.Type1;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        Console.WriteLine("Hello world");


       






        app.Run();
    }

    private static TextCorpus CreateCorpus(string path)
    {
        PdfPigReader reader = new PdfPigReader();
        var doc = reader.ReadFromPath(path);
        return new TextCorpus(doc.ToString());
    }
}
#endif