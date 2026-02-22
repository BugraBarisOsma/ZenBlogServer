
using FluentValidation;
using ZenBlog.Application.Base;

namespace ZenBlog.API.CustomMiddleware
{
    public class CustomExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var response = new BaseResult<object>()
                {
                    Errors = ex.Errors.GroupBy(e => e.PropertyName)
                    .Select(g => new Error{ 
                        PropertyMessage = g.Key,
                        ErrorMessage = g.Select(e => e.ErrorMessage).FirstOrDefault()}).ToList(),
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new BaseResult<object>()
                {
                    Errors = new List<Error>
                    {
                        new Error { ErrorMessage = ex.Message }
                    }
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
