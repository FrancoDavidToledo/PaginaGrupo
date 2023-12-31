﻿namespace PaginaGrupo.Core.Entities;

public class NombreScout : BaseEntity
{
    public int? IdTipo { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public string? CodigoUnidad { get; set; }

    public int? IdScout { get; set; }

    public virtual Unidad? CodigoUnidadNavigation { get; set; }

    public virtual Scout? IdScoutNavigation { get; set; }

    public virtual TipoNombre? IdTipoNavigation { get; set; }
}
