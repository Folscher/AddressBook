using AddressBook.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace AddressBook.Api.Infrastructure
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = this.UnwrapException(context.Exception);

            if (exception is AddressBookException)
            {
                var valitionExeption = (AddressBookException)exception;
                context.Result = new BadRequestObjectResult(valitionExeption.Errors);
            }
            else
            {
                context.Result = new ObjectResult(new { message = exception.Message, innerException = exception.InnerException?.ToString() });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }

        private Exception UnwrapException(Exception ex)
        {
            if (ex is TargetInvocationException)
            {
                return ex.InnerException;
            }

            return ex;
        }
    }
}
