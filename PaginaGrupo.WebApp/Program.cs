//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using PaginaGrupo.WebApp;
//using Blazored.Toast;

////aca empiezan implementaciones
//using PaginaGrupo.WebApp.Servicios.Contrato;
//using PaginaGrupo.WebApp.Servicios.Implementacion;

//using CurrieTechnologies.Razor.SweetAlert2;
//using PaginaGrupo.WebApp.Extensiones;

//using Microsoft.AspNetCore.Components.Authorization;


//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

////builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:63191/") });

//builder.Services.AddBlazoredToast();

//builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();


//builder.Services.AddSweetAlert2();

//builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();

//await builder.Build().RunAsync();


using PaginaGrupo.WebApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using Blazored.Toast;


using PaginaGrupo.WebApp.Servicios.Contrato;
using PaginaGrupo.WebApp.Servicios.Implementacion;

using CurrieTechnologies.Razor.SweetAlert2;

using Microsoft.AspNetCore.Components.Authorization;
using PaginaGrupo.WebApp.Extensiones;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using PaginaGrupo.WebApp.Extensiones;
using PaginaGrupo.WebApp.Servicios.Contrato;
using PaginaGrupo.WebApp.Servicios.Implementacion;
using PaginaGrupo.WebApp;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://www.gruposcout.somee.com/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7105/") });


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IAdjuntoServicio, AdjuntoServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<INoticiaServicio, NoticiaServicio>();
builder.Services.AddScoped<IScoutServicio, ScoutServicio>();
builder.Services.AddScoped<IUnidadServicio, UnidadServicio>();
builder.Services.AddScoped<IComentarioServicio, ComentarioServicio>();
builder.Services.AddScoped<ITipoNombreServicio, TipoNombreServicio>();
builder.Services.AddScoped<INombreScoutServicio, NombreScoutServicio>();

builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddBlazorBootstrap();


await builder.Build().RunAsync();
