using AutoMapper;
using PaginaGrupo.Core.DTOs;
using PaginaGrupo.Core.Entities;
using PaginaGrupo.Infra.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaGrupo.Infra.Mappings
{
    public class AutomapperProfile : Profile
    {


        public AutomapperProfile() 
        {
            CreateMap<Adjuntos, AdjuntosDto>();
            CreateMap<AdjuntosDto, Adjuntos>();

            CreateMap<AsistenciaScout, AsistenciaScoutDto>();
            CreateMap<AsistenciaScoutDto, AsistenciaScout>();

            CreateMap<Autores, AutoresDto>();
            CreateMap<AutoresDto, Autores>();

            CreateMap<AvisoPago, AvisoPagoDto>();
            CreateMap<AvisoPagoDto, AvisoPago>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<Comentario, ComentarioDto>();
            CreateMap<ComentarioDto, Comentario>();

            CreateMap<Fecha, FechaDto>();
            CreateMap<FechaDto, Fecha>();

            CreateMap<HistoricoUsuario, HistoricoUsuarioDto>();
            CreateMap<HistoricoUsuarioDto, HistoricoUsuario>();

            CreateMap<Libro, LibroDto>();
            CreateMap<LibroDto, Libro>();

            CreateMap<LibroAutor, LibroAutorDto>();
            CreateMap<LibroAutorDto, LibroAutor>();

            CreateMap<LibroCategoria, LibroCategoriaDto>();
            CreateMap<LibroCategoriaDto, LibroCategoria>();

            CreateMap<NombreScout, NombreScoutDto>();
            CreateMap<NombreScoutDto, NombreScout>();

            CreateMap<Noticias, NoticiaDto>();
            CreateMap<NoticiaDto, Noticias>();

            CreateMap<Progresion, ProgresionDto>();
            CreateMap<ProgresionDto, Progresion>();

            CreateMap<ProgresionScout, ProgresionScoutDto>();
            CreateMap<ProgresionScoutDto, ProgresionScout>();

            CreateMap<Rama, RamaDto>();
            CreateMap<RamaDto, Rama>();

            CreateMap<Roles, RolesDto>();
            CreateMap<RolesDto, Roles>();

            CreateMap<RolesUsuario, RolesUsuarioDto>();
            CreateMap<RolesUsuarioDto, RolesUsuario>();

            CreateMap<Scout, ScoutDto>();
            CreateMap<ScoutDto, Scout> ();

            CreateMap<TipoAdjunto, TipoAdjuntoDto>();
            CreateMap<TipoAdjuntoDto, TipoAdjunto>();

            CreateMap<TipoNombre, TipoNombreDto>();
            CreateMap<TipoNombreDto, TipoNombre>();

            CreateMap<Unidad, UnidadDto>();
            CreateMap<UnidadDto, Unidad>();

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
