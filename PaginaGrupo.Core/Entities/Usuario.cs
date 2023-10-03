﻿namespace PaginaGrupo.Core.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaUltimoIngreso { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<HistoricoUsuario> HistoricoUsuarios { get; set; } = new List<HistoricoUsuario>();

    public virtual ICollection<Noticias> NoticiaIdUsuarioBajaNavigations { get; set; } = new List<Noticias>();

    public virtual ICollection<Noticias> NoticiaIdUsuarioNavigations { get; set; } = new List<Noticias>();

    public virtual ICollection<RolesUsuario> RolesUsuarios { get; set; } = new List<RolesUsuario>();
}
