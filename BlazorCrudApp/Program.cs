using BlazorCrudApp.Interfaces;
using BlazorCrudApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorCrudApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        var apiUrl = config["ApiUrl:Base"];

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri($"{apiUrl}") });

        builder.Services.AddSingleton<IConfiguration>(config);
        builder.Services.AddScoped<IBookService, BookService>();

        await builder.Build().RunAsync();
    }
}
