#define PLAYGROUND

#if PLAYGROUND
namespace DoccCloud;

using DocCloud.Model.PdfPig;
using DocCloud.Model.TextProcessing;
using UglyToad.PdfPig.Fonts.Type1;

public static class ProgramPlayground
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
        PdfPigReader reader = new PdfPigReader();
        var doc = reader.ReadFromPath("20179.pdf");
        Console.WriteLine(doc.Pages[0].Content.ToString());


        IWordFilter filter = new SmallOrFrequentWordFilter();
        IWordMetric metric = new WordLengthImportanceMetric();
        TextCorpus corpus =  CreateCorpus("20179.pdf");
        TextCorpus archiveCorpus = CreateCorpus("20180.pdf");



        var words = corpus.GetMostImportantWords(10, filter, metric, archiveCorpus).ToList();
        foreach (var word in words)
        {
            Console.WriteLine(word);
            Console.WriteLine(metric.Evaluate(word, corpus, archiveCorpus));
            Console.WriteLine("Archive Corpus: " + archiveCorpus.GetFrequency(word) + " "+ archiveCorpus.GetRelativeFrequency(word));
            Console.WriteLine("New Corpus: " + corpus.GetFrequency(word) + " "+ corpus.GetRelativeFrequency(word));
            Console.WriteLine();

        }






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