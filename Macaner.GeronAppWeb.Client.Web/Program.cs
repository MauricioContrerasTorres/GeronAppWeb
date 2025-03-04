using Macaner.GeronAppWeb.Client.Web;
using Macaner.GeronAppWeb.Service.Interface;
using Macaner.GeronAppWeb.Service.ApiServices;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Macaner.GeronAppWeb.Shared.Interface;
using Macaner.GeronAppWeb.Shared.Common;
using System.Text.Json;



var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Crear una instancia de ConfigurationBuilder
var configBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);






//// Crear instancia de HttpClient para obtener appsettings.json
//using var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

//// Cargar y deserializar el contenido de appsettings.json
//var appSettingsJson = await httpClient.GetStringAsync("appsettings.json");
//var appSettings = JsonSerializer.Deserialize<Dictionary<string, string>>(appSettingsJson);

//// Registrar configuración en el contenedor de servicios
//var configBuilder = new ConfigurationBuilder()
//    .AddInMemoryCollection(appSettings)
//    .Build();
//builder.Services.AddSingleton<IConfiguration>(configBuilder);

builder.Services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
builder.Services.AddScoped<IConnectionService, ConnectionService>();
builder.Services.AddScoped<ISenderApi, SenderApi>();
builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<LoadingService>();
builder.Services.AddScoped<IRegionService,RegionService>();
builder.Services.AddScoped<IComunaService, ComunaService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAlergiaService, AlergiaService>();
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();
builder.Services.AddScoped<ISexoService, SexoService>();




await builder.Build().RunAsync();
