using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class ComentarioValidator : AbstractValidator<ComentarioDto>
    {
        public ComentarioValidator()
        {

            RuleFor(comentario => comentario.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(comentario => comentario.Fecha)
                .NotNull()
                .WithMessage("El campo 'Fecha' no debe ser nulo");

            RuleFor(comentario => comentario.Contenido)
                .NotNull()
                .WithMessage("El campo 'Contenido' no debe ser nulo");

            RuleFor(comentario => comentario.Contenido)
                .Length(1, 500)
                .WithMessage("El campo 'Contenido' debe tener entre 1 y 500 caracteres");

            RuleFor(comentario => comentario.IdUsuario)
                .NotNull()
                .WithMessage("El campo 'IdUsuario' no debe ser nulo");

            RuleFor(comentario => comentario.IdNoticia)
                .NotNull()
                .WithMessage("El campo 'IdNoticia' no debe ser nulo");
        }
    }
}
