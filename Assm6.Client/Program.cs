using Assm6.Client;
using Assm6.Client.Authentication;
using Assm6.Client.AuthProviders;
using Assm6.Client.MonHocs;
using Assm6.Client.Nganhs;
using Assm6.Client.SinhVienInMonHocs;
using AssmentCshap6.Data.Enum;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7249/api/") });
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<INganhClient, NganhClient>();
builder.Services.AddTransient<IMonhocClient, MonhocClient>();
builder.Services.AddTransient<ISinhvienInMonHocClient, SinhvienInMonHocClient>();

await builder.Build().RunAsync();
