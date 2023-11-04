using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class ScoutValidator : AbstractValidator<ScoutDto>
    {
        public ScoutValidator()
        {
            RuleFor(scout => scout.Nombre)
                .NotNull()
                .WithMessage("El campo 'Nombre' no debe ser nulo");

            RuleFor(scout => scout.Nombre)
                .Length(0, 30)
                .WithMessage("El campo 'Nombre' no debe exceder los 30 caracteres");

            RuleFor(scout => scout.Apellido)
                 .NotNull()
                 .WithMessage("El campo 'Apellido' no debe ser nulo");

            RuleFor(scout => scout.Apellido)
                .Length(0, 30)
                .WithMessage("El campo 'Apellido' no debe exceder los 30 caracteres");

            RuleFor(scout => scout.Id)
                 .NotNull()
                 .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(scout => scout.Dni)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El campo 'DNI' debe ser un número positivo");

            RuleFor(scout => scout.Dni)
                .NotNull()
                .WithMessage("El campo 'Dni' no debe ser nulo");

            RuleFor(scout => scout.FechaNacimiento)
                .NotNull()
                .WithMessage("El campo 'FechaNacimiento' no debe ser nulo");

            RuleFor(scout => scout.Sexo)
                .Length(0, 1)
                .WithMessage("El campo 'Sexo' debe tener un carácter");

            RuleFor(scout => scout.Telefono)
                .Length(0, 50)
                .WithMessage("El campo 'Telefono' no debe exceder los 50 caracteres");

            RuleFor(scout => scout.Correo)
                .Length(0, 50)
                .WithMessage("El campo 'Correo' no debe exceder los 50 caracteres");

            RuleFor(scout => scout.Direccion)
                .Length(0, 50)
                .WithMessage("El campo 'Direccion' no debe exceder los 50 caracteres");

            RuleFor(scout => scout.CodigoUnidad)
                .Length(0, 10)
                .WithMessage("El campo 'CodigoUnidad' no debe exceder los 10 caracteres");

            RuleFor(scout => scout.Estado)
                 .NotNull()
                 .WithMessage("El campo 'Estado' no debe ser nulo");
        }
    }
}
