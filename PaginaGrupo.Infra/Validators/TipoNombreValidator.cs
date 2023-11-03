using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class TipoNombreValidator : AbstractValidator<TipoNombreDto>
    {
        public TipoNombreValidator()
        {
            RuleFor(tipo => tipo.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");
            RuleFor(tipo => tipo.Tipo)
                .NotNull()
                .WithMessage("El campo 'Tipo' no debe ser nulo");

            RuleFor(tipo => tipo.Tipo)
                .Length(1, 25)
                .WithMessage("El campo 'Tipo' debe tener entre 1 y 25 caracteres");
        }
    }
}
