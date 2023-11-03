using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class LibroCategoriaValidator : AbstractValidator<LibroCategoriaDto>
    {
        public LibroCategoriaValidator()
        {
            RuleFor(libroCategoria => libroCategoria.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(libroCategoria => libroCategoria.IdLibro)
                .NotNull()
                .WithMessage("El campo 'IdLibro' no debe ser nulo");

            RuleFor(libroCategoria => libroCategoria.IdCategoria)
                .NotNull()
                .WithMessage("El campo 'IdCategoria' no debe ser nulo");
        }
    }
}
