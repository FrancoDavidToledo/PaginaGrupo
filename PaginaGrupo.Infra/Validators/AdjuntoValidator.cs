using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class AdjuntoValidator : AbstractValidator<AdjuntosDto>
    {
        public AdjuntoValidator()
        {
            RuleFor(adjunto => adjunto.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(adjunto => adjunto.Adjunto)
                .NotNull()
                .WithMessage("El campo 'Adjunto' no debe ser nulo");

            RuleFor(adjunto => adjunto.Adjunto)
                .Length(1, 400)
                .WithMessage("El campo 'Adjunto' debe tener entre 1 y 400 caracteres");

            RuleFor(adjunto => adjunto.IdNoticia)
                .NotNull()
                .WithMessage("El campo 'IdNoticia' no debe ser nulo");
        }
    }
}
