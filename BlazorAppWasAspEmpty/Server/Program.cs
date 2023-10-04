using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseBlazorFrameworkFiles();

//default values to StaticFileOptions
StaticFileOptions staticFileOptions = new StaticFileOptions();
staticFileOptions.DefaultContentType = "none";
staticFileOptions.ServeUnknownFileTypes = false;
app.UseStaticFiles(staticFileOptions);

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();