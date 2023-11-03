using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class CategoriaValidator : AbstractValidator<CategoriaDto>
    {
        public CategoriaValidator()
        {
            RuleFor(categoria => categoria.Id)
                 .NotNull()
                 .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(categoria => categoria.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(categoria => categoria.Nombre)
                .Length(1, 100)
                .WithMessage("El campo 'Nombre' debe tener entre 1 y 100 caracteres");
        }
    }
}
