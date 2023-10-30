using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class NoticiaValidator : AbstractValidator<NoticiaDto>
    {
        public NoticiaValidator()
        {
            RuleFor(noticia => noticia.Titulo)
            .NotNull()
            .WithMessage("El titulo no debe ser nulo")
            ;
            RuleFor(noticia => noticia.Titulo)
            .Length(10,60)
            .WithMessage("El titulo debe tener entre 10 y 60 caracteres")
;

        }
    }
}
