using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class LibroAutorValidator : AbstractValidator<LibroAutorDto>
    {
        public LibroAutorValidator()
        {
            RuleFor(libroAutor => libroAutor.Id)
                 .NotNull()
                 .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(libroAutor => libroAutor.IdLibro)
                .NotNull()
                .WithMessage("El campo 'IdLibro' no debe ser nulo");

            RuleFor(libroAutor => libroAutor.IdAutor)
                .NotNull()
                .WithMessage("El campo 'IdAutor' no debe ser nulo");
        }
    }
}
