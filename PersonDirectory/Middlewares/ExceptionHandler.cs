using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using PersonDirectory.Common.Exceptions;

namespace PersonDirectory.API.Middlewares
{
    public class ExceptionHandler(RequestDelegate _next, ILogger<ExceptionHandlerMiddleware> _logger)
    {

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case AlreadyExistsException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    break;
                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case Common.Exceptions.ArgumentException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case ValidationException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var result = JsonConvert.SerializeObject(new
            {
                error = exception.Message
            });

            return context.Response.WriteAsync(result);
        }
    }
}
