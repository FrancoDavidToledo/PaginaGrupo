using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class TipoAdjuntoValidator : AbstractValidator<TipoAdjuntoDto>
    {
        public TipoAdjuntoValidator()
        {
            RuleFor(tipo => tipo.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");
            RuleFor(tipo => tipo.Tipo)
                .NotNull()
                .WithMessage("El campo 'Tipo' no debe ser nulo");

            RuleFor(tipo => tipo.Tipo)
                .Length(1, 5)
                .WithMessage("El campo 'Tipo' debe tener entre 1 y 5 caracteres");
        }
    }
}
