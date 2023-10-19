using Microsoft.EntityFrameworkCore;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Infra.Data;
using PaginaGrupo.Infra.Filters;
using PaginaGrupo.Infra.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using PaginaGrupo.Core.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    //esto es para evitar las referencias circulares
    options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}
);

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();

//aca se agrega el "singleton" de dependencia injectada, es como el addtransient
builder.Services.AddScoped<IAdjuntosRepository, AdjuntosRepository>();
builder.Services.AddScoped<IAsistenciaScoutRepository, AsistenciaScoutRepository>();
builder.Services.AddScoped<IAutoresRepository, AutorRepository>();
builder.Services.AddScoped<IAvisoPagoRepository, AvisoPagoRepository>();
builder.Services.AddScoped<ICategoriasRepository, CategoriaRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IFechaRepository, FechaRepository>();
builder.Services.AddScoped<ILibroAutorRepository, LibroAutorRepository>();
builder.Services.AddScoped<ILibroCategoriaRepository, LibroCategoriaRepository>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<INombreScoutRepository, NombreScoutRepository>();
builder.Services.AddScoped<INoticiasRepository, NoticiasRepository>();
builder.Services.AddScoped<IProgresionRepository, ProgresionRepository>();
builder.Services.AddScoped<IProgresionScoutRepository, ProgresionScoutRepository>();
builder.Services.AddScoped<IRamaRepository, RamaRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRolesUsuarioRepository, RolesUsuarioRepository>();
builder.Services.AddScoped<IScoutRepository, ScoutRepository>();
builder.Services.AddScoped<ITipoAdjuntoRepository, TipoAdjuntoRepository>();
builder.Services.AddScoped<ITipoNombreRepository, TipoNombreRepository>();
builder.Services.AddScoped<IUnidadRepository, UnidadRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<INoticiasService, NoticiasService>();

//con esto se conecta a la bbdd del appSettings
builder.Services.AddDbContext<PaginaGrupoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaginaGrupo"));

});

//para el filter
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

var app = builder.Build();



//var noticia = app.Services.GetServices<PaginaGrupo.Core.Interfaces.INoticiasRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
