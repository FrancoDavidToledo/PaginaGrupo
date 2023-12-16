namespace PaginaGrupo.Core.DTOs;
public class UnidadDto
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string CodigoRama { get; set; } = null!;
    public short Orden { get; set; }
}
