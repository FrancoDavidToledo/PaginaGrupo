namespace PaginaGrupo.Core.DTOs;

public class ProgresionDto
{
    public int Id { get; set; }

    public string CodigoRama { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public short Orden { get; set; }

}
