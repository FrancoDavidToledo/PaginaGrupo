using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class UsuarioSinClaveValidator : AbstractValidator<UsuarioDtoSinClave>
    {
        public UsuarioSinClaveValidator()
        {
            RuleFor(usuario => usuario.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");
            RuleFor(usuario => usuario.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(usuario => usuario.Nombre)
                .Length(1, 50)
                .WithMessage("El campo 'Nombre' debe tener entre 1 y 50 caracteres");

            RuleFor(usuario => usuario.Correo)
                .NotNull()
                .WithMessage("El campo 'Correo' no debe ser nulo");

            RuleFor(usuario => usuario.Correo)
                .Length(1, 60)
                .WithMessage("El campo 'Correo' debe tener entre 1 y 60 caracteres");


            RuleFor(usuario => usuario.FechaAlta)
                .NotNull()
                .WithMessage("El campo 'FechaAlta' no debe ser nulo");

            RuleFor(usuario => usuario.Rol)
                 .NotNull()
                 .WithMessage("El campo 'Rol' no debe ser nulo");

            //TODO Chequear esto. Lo comenté porque tiene sentido que sea nulleable hasta el momento en el que el usuairo ingresa realmente.

            //RuleFor(usuario => usuario.FechaUltimoIngreso)
            //    .NotNull()
            //    .WithMessage("El campo 'FechaUltimoIngreso' no debe ser nulo");
        }
    }
}
