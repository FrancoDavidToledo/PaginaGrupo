using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class ProgresionScoutValidator : AbstractValidator<ProgresionScoutDto>
    {
        public ProgresionScoutValidator()
        {

            RuleFor(progresionScout => progresionScout.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(progresionScout => progresionScout.IdScout)
                .NotNull()
                .WithMessage("El campo 'IdScout' no debe ser nulo");

            RuleFor(progresionScout => progresionScout.IdProgresion)
                .NotNull()
                .WithMessage("El campo 'IdProgresion' no debe ser nulo");

            RuleFor(progresionScout => progresionScout.Fecha)
                .NotNull()
                .WithMessage("El campo 'Fecha' no debe ser nulo");
        }
    }
}
