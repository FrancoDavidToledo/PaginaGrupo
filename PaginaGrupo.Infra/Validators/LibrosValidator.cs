using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class LibrosValidator : AbstractValidator<LibroDto>
    {
        public LibrosValidator()
        {
            RuleFor(libro => libro.Id)
                 .NotNull()
                 .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(libro => libro.Codigo)
                .NotNull()
                .WithMessage("El campo 'Codigo' no debe ser nulo");

            RuleFor(libro => libro.Codigo)
                .Length(1, 20)
                .WithMessage("El campo 'Codigo' debe tener entre 1 y 20 caracteres");

            RuleFor(libro => libro.Idioma)
                .Length(0, 50)
                .WithMessage("El campo 'Idioma' no debe exceder los 50 caracteres");

            //TODO se comenta por casos de uso real.

            //RuleFor(libro => libro.Anio)
            //    .NotNull()
            //    .WithMessage("El campo 'Anio' no debe ser nulo");

            //RuleFor(libro => libro.Paginas)
            //    .NotNull()
            //    .WithMessage("El campo 'Paginas' no debe ser nulo");

            RuleFor(libro => libro.Formato)
                .Length(0, 10)
                .WithMessage("El campo 'Formato' no debe exceder los 10 caracteres");

            RuleFor(libro => libro.Url)
                .NotNull()
                .WithMessage("El campo 'Url' no debe ser nulo");

            RuleFor(libro => libro.UrlPortada)
                .NotNull()
                .WithMessage("El campo 'UrlPortada' no debe ser nulo");
        }
    }
}
