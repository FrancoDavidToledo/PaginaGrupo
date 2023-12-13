using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaGrupo.Core.DTOs;

public class AdjuntosDto
{
    public int Id { get; set; }

    public string Adjunto { get; set; }

    public int IdNoticia {  get; set; }


}
