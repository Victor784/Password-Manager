using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PasswordManagerClient;
using PasswordManagerClient.ApiReturnTypes;
using PasswordManagerClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseAddress = "https://localhost:44333";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

builder.Services.AddScoped<UserApiClient>();
builder.Services.AddScoped<PasswordApiClient>();
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<IClipboardService, ClipboardService>();
builder.Services.AddScoped<ExpirationCalculator>();
builder.Services.AddScoped<PasswordGenerator>();
builder.Services.AddScoped<UserStateService>();

await builder.Build().RunAsync();
