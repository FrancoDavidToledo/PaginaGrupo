﻿using PaginaGrupo.Core.Entities;

namespace PaginaGrupo.Core.Interfaces
{
    public interface IAvisoPagoRepository : IRepository<AvisoPago>
    {
        Task<IEnumerable<AvisoPago>> GetAvisosPagosUsuario(int idUsuario);

    }
}
