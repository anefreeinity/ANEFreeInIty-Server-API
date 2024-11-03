using ANEFreeInIty_Server_API.Model.Dtos.Error;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ANEFreeInIty_Server_API.Extensions.Exceptions;
public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;
                    context.Response.StatusCode = exception switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    var errorMessage = contextFeature.Error.Message;
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                    }
                    await context.Response.WriteAsync(
                        JsonSerializer.Serialize(
                            new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = exception.Message
                            }));
                }
            });
        });
    }
}
