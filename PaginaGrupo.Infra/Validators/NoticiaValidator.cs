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
            .Length(10, 60);
        }
    }
}
