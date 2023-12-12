using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class FechasValidator : AbstractValidator<FechaDto>
    {
        public FechasValidator()
        {
            RuleFor(fecha => fecha.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(fecha => fecha.Fecha) //fecha1 porque en el DTO está de esta manera.
                .NotNull()
                .WithMessage("El campo 'Fecha' no debe ser nulo");

            RuleFor(fecha => fecha.AnioScout)
                .NotNull()
                .WithMessage("El campo 'AnioScout' no debe ser nulo");
        }
    }
}
