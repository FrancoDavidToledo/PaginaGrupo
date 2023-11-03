using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class NombreScoutValidator : AbstractValidator<NombreScoutDto>
    {
        public NombreScoutValidator()
        {

            RuleFor(scout => scout.Id)
                 .NotNull()
                 .WithMessage("El campo 'ID' no debe ser nulo");
            RuleFor(scout => scout.IdTipo)
                .NotNull()
                .WithMessage("El campo 'IdTipo' no debe ser nulo");

            RuleFor(scout => scout.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(scout => scout.Nombre)
                .Length(1, 30)
                .WithMessage("El campo 'Nombre' debe tener entre 1 y 30 caracteres");

            RuleFor(scout => scout.Fecha)
                .NotNull()
                .WithMessage("El campo 'Fecha' no debe ser nulo");

            RuleFor(scout => scout.CodigoUnidad)
                .NotNull()
                .WithMessage("El campo 'CodigoUnidad' no debe ser nulo");

            RuleFor(scout => scout.CodigoUnidad)
                .Length(1, 10)
                .WithMessage("El campo 'CodigoUnidad' debe tener entre 1 y 10 caracteres");

            RuleFor(scout => scout.IdScout)
                .NotNull()
                .WithMessage("El campo 'IdScout' no debe ser nulo");
        }
    }
}
