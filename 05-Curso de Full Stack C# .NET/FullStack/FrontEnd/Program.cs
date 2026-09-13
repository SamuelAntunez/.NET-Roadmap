using FluentValidation;
using Frontend.Client;
using FrontEnd;
using FrontEnd.Validators;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var backendUrl = builder.Configuration["BackendUrl"]; // Obtener url de appsettings.json


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("Backend", http => 
{
    http.BaseAddress = new Uri(backendUrl);
});

builder.Services.AddScoped(sp =>
{
    var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient("Backend");
    var client = new ApiClient(http);
    client.ReadResponseAsString = true;
    return client;
});

await builder.Build().RunAsync();
