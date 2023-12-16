using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class NoticiaValidator : AbstractValidator<NoticiaDto>
    {
        public NoticiaValidator()
        {

            RuleFor(noticia => noticia.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(noticia => noticia.Titulo)
                .NotNull()
                .WithMessage("El campo 'Titulo' no debe ser nulo");

            RuleFor(noticia => noticia.Titulo)
                .Length(1, 60)
                .WithMessage("El campo 'Titulo' debe tener entre 1 y 60 caracteres");

            RuleFor(noticia => noticia.Autor)
                .NotNull()
                .WithMessage("El campo 'Autor' no debe ser nulo");

            RuleFor(noticia => noticia.Autor)
                .Length(1, 50)
                .WithMessage("El campo 'Autor' debe tener entre 1 y 50 caracteres");

            RuleFor(noticia => noticia.FechaNoticia)
                .NotNull()
                .WithMessage("El campo 'FechaNoticia' no debe ser nulo");

            RuleFor(noticia => noticia.Estado)
                .NotNull()
                .WithMessage("El campo 'Estado' no debe ser nulo");

            RuleFor(noticia => noticia.FechaBaja)
                .NotEmpty()
                .When(noticia => noticia.Estado == 4)
                .WithMessage("El campo 'FechaBaja' es requerido cuando el estado es 4 (baja)");


            RuleFor(noticia => noticia.IdUsuarioBaja)
                .NotEmpty()
                .When(noticia => noticia.Estado == 4)
                .WithMessage("El campo 'IdUsuarioBaja' es requerido cuando el estado es 4 (baja)");


        }
    }
}
