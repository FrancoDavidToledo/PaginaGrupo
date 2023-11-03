using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidator()
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

            RuleFor(usuario => usuario.Clave)
                .NotNull()
                .WithMessage("El campo 'Clave' no debe ser nulo");

            RuleFor(usuario => usuario.Clave)
                .Length(1, 500)
                .WithMessage("El campo 'Clave' debe tener entre 1 y 500 caracteres");

            RuleFor(usuario => usuario.FechaAlta)
                .NotNull()
                .WithMessage("El campo 'FechaAlta' no debe ser nulo");

            RuleFor(usuario => usuario.FechaUltimoIngreso)
                .NotNull()
                .WithMessage("El campo 'FechaUltimoIngreso' no debe ser nulo");
        }
    }
}
