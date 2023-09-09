using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using TransportGlobal.Application.DTOs.ResponseDTOs;
using TransportGlobal.Domain.Constants;
using TransportGlobal.Domain.Exceptions;

namespace TransportGlobal.API.Extensions.Handlers
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    IExceptionHandlerFeature? exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionFeature == null) return;

                    HttpStatusCode statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => HttpStatusCode.BadRequest,
                        NotFoundException => HttpStatusCode.NotFound,
                        _ => HttpStatusCode.InternalServerError,
                    };

                    string errorMessage = statusCode switch
                    {
                        HttpStatusCode.InternalServerError => ExceptionConstants.ServerSideException,
                        _ => exceptionFeature.Error.Message
                    };

                    context.Response.StatusCode = (int)statusCode;

                    APIResponseDTO response = new(statusCode, errorMessage);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
