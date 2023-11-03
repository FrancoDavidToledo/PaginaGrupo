using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    //TODO me estaria faltando la DTO de rol (Puede ser que la logia sea solo manejarlo por base de datos)

    //public class RolesValidator : AbstractValidator<RolDto>
    //{
    //    public RolesValidator()
    //    {

    //        RuleFor(rol => rol.Id)
    //            .NotNull()
    //            .WithMessage("El campo 'ID' no debe ser nulo");
    //        RuleFor(rol => rol.Codigo)
    //            .NotNull()
    //            .WithMessage("El campo 'Codigo' no debe ser nulo");

    //        RuleFor(rol => rol.Codigo)
    //            .Length(1, 50)
    //            .WithMessage("El campo 'Codigo' debe tener entre 1 y 50 caracteres");

    //        RuleFor(rol => rol.Descripcion)
    //            .Length(0, 500)
    //            .WithMessage("El campo 'Descripcion' no debe exceder los 500 caracteres");
    //    }
    //}
}
