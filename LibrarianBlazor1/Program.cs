using LibrarianBlazor1;
using LibrarianBlazor1.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7132") });

builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddScoped<IRentalServices, RentalServices>();
builder.Services.AddScoped<IBookServices, BookServices>();
await builder.Build().RunAsync();
