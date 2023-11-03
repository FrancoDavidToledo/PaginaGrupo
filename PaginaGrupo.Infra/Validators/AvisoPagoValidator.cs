using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class AvisoPagoValidator : AbstractValidator<AvisoPagoDto>
    {
        public AvisoPagoValidator()
        {
            RuleFor(aviso => aviso.Id)
                 .NotNull()
                 .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(aviso => aviso.Importe)
                .NotNull()
                .WithMessage("El campo 'Importe' no debe ser nulo");

            RuleFor(aviso => aviso.Comentario)
                .Length(0, 500)
                .WithMessage("El campo 'Comentario' no debe exceder los 500 caracteres");

            RuleFor(aviso => aviso.Fecha)
                .NotNull()
                .WithMessage("El campo 'Fecha' no debe ser nulo");

            RuleFor(aviso => aviso.Comprobante)
                .Length(0, 400)
                .WithMessage("El campo 'Comprobante' no debe exceder los 400 caracteres");

            RuleFor(aviso => aviso.IdUsuario)
                .NotNull()
                .WithMessage("El campo 'IdUsuario' no debe ser nulo");
        }
    }
}
