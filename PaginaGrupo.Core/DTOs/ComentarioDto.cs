﻿namespace PaginaGrupo.Core.DTOs;
public class ComentarioDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Contenido { get; set; } = null!;
    public int IdUsuario { get; set; }
    public int IdNoticia { get; set; }
    public int Estado { get; set; }
    public string? NombreUsuario { get; set; }
    public string? TituloNoticia { get; set; }
}
