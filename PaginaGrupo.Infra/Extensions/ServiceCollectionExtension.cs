using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaginaGrupo.Core.CustomEntitys;
using PaginaGrupo.Core.Interfaces;
using PaginaGrupo.Core.Services;
using PaginaGrupo.Infra.Data;
using PaginaGrupo.Infra.Repositories;

namespace PaginaGrupo.Infra.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddDbContext<PaginaGrupoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PaginaGrupo"));
            });
            return builder;
        }

        public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
        {
            //paginacion
            builder.Services.Configure<PaginationOptions>(options => builder.Configuration.GetSection("Pagination").Bind(options));

            //hasheo de contraseña
            builder.Services.Configure<Options.PasswordOptions>(options => builder.Configuration.GetSection("PasswordOptions").Bind(options));
            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
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

            builder.Services.AddScoped<IAsistenciaViewRepository, AsistenciaViewRepository>();

            builder.Services.AddScoped<INoticiasService, NoticiasService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IComentarioService, ComentarioService>();
            builder.Services.AddScoped<IAdjuntoService,AdjuntoService>();
            builder.Services.AddScoped<ILibroService, LibroService>();
            builder.Services.AddScoped<IAutorService, AutorService>();
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<IAvisoPagoService, AvisoPagoService>();
            builder.Services.AddScoped<IScoutService, ScoutService>();
            builder.Services.AddScoped<IAsistenciaScoutService, AsistenciaScoutService>();
            builder.Services.AddScoped<INombreScoutService, NombreScoutService>();
            builder.Services.AddScoped<IFechasService, FechasService>();

            return builder;
        }
    }
}
