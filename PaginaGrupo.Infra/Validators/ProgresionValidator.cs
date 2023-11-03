using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class ProgresionValidator : AbstractValidator<ProgresionDto>
    {
        public ProgresionValidator()
        {

            RuleFor(progresion => progresion.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");
            RuleFor(progresion => progresion.CodigoRama)
                .NotNull()
                .WithMessage("El campo 'CodigoRama' no debe ser nulo");

            RuleFor(progresion => progresion.CodigoRama)
                .Length(1, 3)
                .WithMessage("El campo 'CodigoRama' debe tener entre 1 y 3 caracteres");

            RuleFor(progresion => progresion.Tipo)
                .NotNull()
                .WithMessage("El campo 'Tipo' no debe ser nulo");

            RuleFor(progresion => progresion.Tipo)
                .Length(1, 10)
                .WithMessage("El campo 'Tipo' debe tener entre 1 y 10 caracteres");

            RuleFor(progresion => progresion.Sexo)
                .NotNull()
                .WithMessage("El campo 'Sexo' no debe ser nulo");

            RuleFor(progresion => progresion.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(progresion => progresion.Nombre)
                .Length(1, 30)
                .WithMessage("El campo 'Nombre' debe tener entre 1 y 30 caracteres");

            RuleFor(progresion => progresion.Orden)
                .NotNull()
                .WithMessage("El campo 'Orden' no debe ser nulo");
        }


    }
}
