using Blazored.LocalStorage;
using CrimeLogger.Client;
using CrimeLogger.Client.Service;
using CrimeLogger.Client.Service.IService;
using CrimeLogger_Client.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICrimeProvinceCitySuburbService, CrimeProvinceCitySuburbService>();
builder.Services.AddScoped<ICrimeTypeService, CrimeTypeService>();
builder.Services.AddScoped<ICrimeDetailService, CrimeDetailService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
