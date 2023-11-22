using AutoMapper;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Infra.Mappings
{
    public class AutomapperProfile : Profile
    {


        public AutomapperProfile()
        {
            CreateMap<Adjuntos, AdjuntosDto>().ReverseMap();
            //  CreateMap<AdjuntosDto, Adjuntos>();

            CreateMap<AsistenciaScout, AsistenciaScoutDto>().ReverseMap();
            //   CreateMap<AsistenciaScoutDto, AsistenciaScout>();

            CreateMap<Autores, AutoresDto>().ReverseMap();
            //  CreateMap<AutoresDto, Autores>();

            CreateMap<AvisoPago, AvisoPagoDto>().ReverseMap();
            // CreateMap<AvisoPagoDto, AvisoPago>();

            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            // CreateMap<CategoriaDto, Categoria>();

            CreateMap<Comentario, ComentarioDto>().ReverseMap();
            // CreateMap<ComentarioDto, Comentario>();

            CreateMap<Fecha, FechaDto>().ReverseMap();
            // CreateMap<FechaDto, Fecha>();

            CreateMap<HistoricoUsuario, HistoricoUsuarioDto>().ReverseMap();
            // CreateMap<HistoricoUsuarioDto, HistoricoUsuario>();

            CreateMap<Libro, LibroDto>().ReverseMap();
            // CreateMap<LibroDto, Libro>();

            CreateMap<LibroAutor, LibroAutorDto>().ReverseMap();
            // CreateMap<LibroAutorDto, LibroAutor>();

            CreateMap<LibroCategoria, LibroCategoriaDto>().ReverseMap();
            // CreateMap<LibroCategoriaDto, LibroCategoria>();

            CreateMap<NombreScout, NombreScoutDto>().ReverseMap();
            // CreateMap<NombreScoutDto, NombreScout>();

            CreateMap<Noticias, NoticiaDto>().ReverseMap();

            CreateMap<Noticias, NoticiaAltaDto>().ReverseMap();
            //CreateMap<NoticiaDto, Noticias>();

            CreateMap<Progresion, ProgresionDto>().ReverseMap();
            //CreateMap<ProgresionDto, Progresion>();

            CreateMap<ProgresionScout, ProgresionScoutDto>().ReverseMap();
            //CreateMap<ProgresionScoutDto, ProgresionScout>();

            CreateMap<Rama, RamaDto>().ReverseMap();
            //CreateMap<RamaDto, Rama>();

            CreateMap<Scout, ScoutDto>().ReverseMap();
            //CreateMap<ScoutDto, Scout>();

            CreateMap<TipoAdjunto, TipoAdjuntoDto>().ReverseMap();
            // CreateMap<TipoAdjuntoDto, TipoAdjunto>();

            CreateMap<TipoNombre, TipoNombreDto>().ReverseMap();
            // CreateMap<TipoNombreDto, TipoNombre>();

            CreateMap<Unidad, UnidadDto>().ReverseMap();
            // CreateMap<UnidadDto, Unidad>();

            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            // CreateMap<UsuarioDto, Usuario>();

            CreateMap<Usuario, UsuarioDtoSinClave>().ReverseMap();
            CreateMap<Usuario, UsuarioSinClaveTokenDto>().ReverseMap();
        }
    }
}
