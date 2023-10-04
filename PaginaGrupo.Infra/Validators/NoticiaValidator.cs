using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PaginaGrupo.Core.DTOs;

namespace PaginaGrupo.Infra.Validators
{
    public class NoticiaValidator : AbstractValidator<NoticiaDto>
    {
        public NoticiaValidator() 
        {
            RuleFor(noticia => noticia.Titulo)
            .NotNull()
            .Length(10, 60);
        }
    }
}
