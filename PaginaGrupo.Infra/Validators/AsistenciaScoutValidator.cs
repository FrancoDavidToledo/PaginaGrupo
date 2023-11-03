using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class AsistenciaScoutsValidator : AbstractValidator<AsistenciaScoutDto>
    {
        public AsistenciaScoutsValidator()
        {
            RuleFor(asistencia => asistencia.Id)
                .NotNull()
                .WithMessage("El campo 'ID' no debe ser nulo");

            RuleFor(asistencia => asistencia.IdScout)
                .NotNull()
                .WithMessage("El campo 'IdScout' no debe ser nulo");

            RuleFor(asistencia => asistencia.IdFecha)
                .NotNull()
                .WithMessage("El campo 'IdFecha' no debe ser nulo");

            RuleFor(asistencia => asistencia.Asistencia)
                .NotNull()
                .WithMessage("El campo 'Asistencia' no debe ser nulo")
                .Must(asistencia => BeValidAsistencia(asistencia)) 
                //Esto da error porque en la DTO asistencia es string, pero en la base en char(1), si se cambia la DTO se arregla. Si no hay que cambiar la base y la validación de abajo
                .WithMessage("El campo 'Asistencia' debe ser 'S' o 'N'");

            RuleFor(asistencia => asistencia.CodigoUnidad)
                .NotNull()
                .WithMessage("El campo 'CodigoUnidad' no debe ser nulo");

            RuleFor(asistencia => asistencia.CodigoUnidad)
                .Length(1, 10)
                .WithMessage("El campo 'CodigoUnidad' debe tener entre 1 y 10 caracteres");
        }

        private bool BeValidAsistencia(char? asistencia) //Valores para presente o Ausente, se podrian modificar o agregar mas
        {
            return asistencia.HasValue && (asistencia.Value == 'P' || asistencia.Value == 'A');
        }
    }
}
