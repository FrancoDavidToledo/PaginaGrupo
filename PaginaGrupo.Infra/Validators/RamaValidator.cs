using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class RamaValidator : AbstractValidator<RamaDto>
    {
        public RamaValidator()
        {

            RuleFor(rama => rama.Codigo)
                .NotNull()
                .WithMessage("El campo 'Codigo' no debe ser nulo");

            RuleFor(rama => rama.Codigo)
                .Length(1, 3)
                .WithMessage("El campo 'Codigo' debe tener entre 1 y 3 caracteres");

            RuleFor(rama => rama.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(rama => rama.Nombre)
                .Length(1, 30)
                .WithMessage("El campo 'Nombre' debe tener entre 1 y 30 caracteres");

            RuleFor(rama => rama.Color)
                .NotNull()
                .WithMessage("El campo 'Color' no debe ser nulo");

            RuleFor(rama => rama.Color)
                .Length(1, 30)
                .WithMessage("El campo 'Color' debe tener entre 1 y 30 caracteres");

            RuleFor(rama => rama.Sexo)
                .NotNull()
                .WithMessage("El campo 'Sexo' no debe ser nulo");
        }


    }
}
