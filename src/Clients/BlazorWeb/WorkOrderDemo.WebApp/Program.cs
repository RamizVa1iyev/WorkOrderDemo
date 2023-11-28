using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WorkOrderDemo.WebApp;
using WorkOrderDemo.WebApp.Services;
using WorkOrderDemo.WebApp.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorBootstrap();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7235/api/") });

builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();
builder.Services.AddScoped<IVisitService, VisitService>();

await builder.Build().RunAsync();
