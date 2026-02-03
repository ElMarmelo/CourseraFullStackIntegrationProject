using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ClientApp;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ProductDataService>();
builder.Services.AddScoped(Span => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5250/")
});
builder.Services.AddScoped<ProductDataService>();


await builder.Build().RunAsync();
