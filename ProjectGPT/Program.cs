using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ElectronNET.API;
using OpenAI.Net;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddOpenAIServices(o =>
{
    o.ApiKey = builder.Configuration["OpenAI:ApiKey"];
});




builder.Services.AddElectron();
builder.WebHost.UseElectron(args);
if (HybridSupport.IsElectronActive)
{
    Task.Run(async () =>{ 
        var window = await Electron.WindowManager.CreateWindowAsync();
        window.OnClose += () => {
         Electron.App.Quit();
        };
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
