using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using recipes_alexander_ccoa.Client;
using recipes_alexander_ccoa.Client.States;
using recipes_alexander_ccoa.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<HttpService>();

builder.Services.AddSingleton<MotorFilterStatus>();

await builder.Build().RunAsync();
