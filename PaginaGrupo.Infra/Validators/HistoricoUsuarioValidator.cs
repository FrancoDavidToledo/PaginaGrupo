using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class HistoricoUsuarioValidator : AbstractValidator<HistoricoUsuarioDto>
    {
        public HistoricoUsuarioValidator()
        {
            RuleFor(historico => historico.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");


            RuleFor(historico => historico.IdUsuario)
                .NotNull()
                .WithMessage("El campo 'IdUsuario' no debe ser nulo");

            RuleFor(historico => historico.Nombre)
                .Length(0, 50)
                .WithMessage("El campo 'Nombre' no debe exceder los 50 caracteres");

            RuleFor(historico => historico.Correo)
                .Length(0, 60)
                .WithMessage("El campo 'Correo' no debe exceder los 60 caracteres");
        }
    }
}
