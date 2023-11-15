using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PaginaGrupo.WebApp;
using Blazored.Toast;

//aca empiezan implementaciones
using PaginaGrupo.WebApp.Servicios.Contrato;
using PaginaGrupo.WebApp.Servicios.Implementacion;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:63191/") });

builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();


await builder.Build().RunAsync();
