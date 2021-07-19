using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

using BlazorBattles.Client.Services;
using Blazored.LocalStorage;
using Blazored.Toast;

namespace BlazorBattles.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)})
                .AddScoped<IBananaService, BananaService>()
                .AddScoped<IUnitService, UnitService>()
                .AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>()
                .AddOptions()
                .AddAuthorizationCore()
                .AddBlazoredToast()
                .AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}
