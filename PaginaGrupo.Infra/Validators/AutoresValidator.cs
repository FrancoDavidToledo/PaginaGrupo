using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class AutoresValidator : AbstractValidator<AutoresDto>
    {
        public AutoresValidator()
        {

            RuleFor(autor => autor.Id)
                 .NotNull()
                 .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(autor => autor.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(autor => autor.Nombre)
                .Length(1, 100)
                .WithMessage("El campo 'Nombre' debe tener entre 1 y 100 caracteres");
        }
    }
}
