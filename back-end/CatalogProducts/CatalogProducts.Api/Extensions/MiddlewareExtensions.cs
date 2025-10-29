using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace CatalogProducts.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionFeature?.Error is ValidationException validationEx)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;

                        var errors = validationEx.Errors
                            .GroupBy(e => e.PropertyName)
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(e => e.ErrorMessage).ToArray()
                            );

                        await context.Response.WriteAsJsonAsync(new
                        {
                            Sucesso = false,
                            Mensagem = "Foram encontrados erros de validação.",
                            Erros = errors
                        });
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Sucesso = false,
                            Mensagem = "Ocorreu um erro inesperado. Tente novamente mais tarde."
                        });
                    }
                });
            });
        }
    }
}
