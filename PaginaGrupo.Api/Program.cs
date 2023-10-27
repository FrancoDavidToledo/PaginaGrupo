using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using PaginaGrupo.Infra.Data;
using PaginaGrupo.Infra.Filters;
using PaginaGrupo.Infra.Interfaces;
using PaginaGrupo.Infra.Repositories;
using PaginaGrupo.Infra.Services;
using System.Diagnostics.SymbolStore;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    //esto es para evitar las referencias circulares
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
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
builder.Services.AddScoped<IScoutRepository, ScoutRepository>();
builder.Services.AddScoped<ITipoAdjuntoRepository, TipoAdjuntoRepository>();
builder.Services.AddScoped<ITipoNombreRepository, TipoNombreRepository>();
builder.Services.AddScoped<IUnidadRepository, UnidadRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<INoticiasService, NoticiasService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//esto es para los paginados, pagina anterior y posterior
builder.Services.AddSingleton<IUriService>(provider =>
{
    var accesor = provider.GetRequiredService<IHttpContextAccessor>();
    var request = accesor.HttpContext.Request;
    var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(absoluteUri);
});

//con esto se conecta a la bbdd del appSettings
builder.Services.AddDbContext<PaginaGrupoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaginaGrupo"));

});

//para el JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]))
    };
}
);

//para el filter
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

//paginacion
builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("Pagination"));


//swagger
builder.Services.AddSwaggerGen(doc =>
{
    doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Pagina Grupo API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    doc.IncludeXmlComments(xmlPath);
});



var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//usar jwt
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
