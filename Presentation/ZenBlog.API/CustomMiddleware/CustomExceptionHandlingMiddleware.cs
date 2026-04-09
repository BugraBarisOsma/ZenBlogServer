
using FluentValidation;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities.Exceptions;

namespace ZenBlog.API.CustomMiddleware
{
    public class CustomExceptionHandlingMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Hatayı logla (Production'da detayları logda görmek icin)
                logger.LogError(ex, "Bir hata oluştu: {Message}", ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // Hata tipine göre StatusCode ve Mesaj belirleme
            var statusCode = exception switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException or UnauthorizedException => StatusCodes.Status401Unauthorized,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var response = new BaseResult<object>()
            {
                Errors = GetErrors(exception)
            };

            await context.Response.WriteAsJsonAsync(response);
        }

        private static List<Error> GetErrors(Exception exception)
        {
            // FluentValidation hataları için özel işleme
            if (exception is ValidationException validationException)
            {
                return validationException.Errors
                    .GroupBy(e => e.PropertyName)
                    .Select(g => new Error
                    {
                        PropertyMessage = g.Key,
                        ErrorMessage = g.Select(e => e.ErrorMessage).FirstOrDefault()
                    }).ToList();
            }

            // Diğer genel hatalar için
            return new List<Error>
        {
            new Error { ErrorMessage = exception.Message }
        };
        }
    }
}
