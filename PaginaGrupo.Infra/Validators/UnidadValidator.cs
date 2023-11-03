using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class UnidadValidator : AbstractValidator<UnidadDto>
    {
        public UnidadValidator()
        {
            RuleFor(unidad => unidad.Codigo)
                .NotNull()
                .WithMessage("El campo 'Codigo' no debe ser nulo");

            RuleFor(unidad => unidad.Codigo)
                .Length(1, 10)
                .WithMessage("El campo 'Codigo' debe tener entre 1 y 10 caracteres");

            RuleFor(unidad => unidad.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(unidad => unidad.Nombre)
                .Length(1, 50)
                .WithMessage("El campo 'Nombre' debe tener entre 1 y 50 caracteres");

            RuleFor(unidad => unidad.CodigoRama)
                .NotNull()
                .WithMessage("El campo 'CodigoRama' no debe ser nulo");

            RuleFor(unidad => unidad.CodigoRama)
                .Length(1, 3)
                .WithMessage("El campo 'CodigoRama' debe tener entre 1 y 3 caracteres");
        }
    }
}
