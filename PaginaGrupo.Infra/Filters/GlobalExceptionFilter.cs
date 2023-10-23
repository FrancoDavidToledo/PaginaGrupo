﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaginaGrupo.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace PaginaGrupo.Infra.Filters
{
    public class GlobalExceptionFilter :IExceptionFilter
    {
        public void OnException(ExceptionContext context) 
        { 
        if (context.Exception.GetType() == typeof(BusinessException)) 
            {
            var exception = (BusinessException)context.Exception;
                var validation = new 
                { Status= 400,
                Title= "Bad Request",
                Detail= exception.Message};
            
            var json = new
            {
                errors = new[] { validation }
            };
                context.Result = new BadRequestObjectResult(json);

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }


        }
    }
}