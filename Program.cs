using DocCloud.Model.PdfPig;

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
PdfPigReader reader=new PdfPigReader();
reader.ReadFromPath("StadtOS_Allgemeinverfügung.pdf");
app.Run();
