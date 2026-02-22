using MediatR;
using ZenBlog.Application.Features.Users.Commands;

namespace ZenBlog.API.Endpoints
{
    public static class UserEndpoints
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder app) 
        {
            var users = app.MapGroup("/users").WithTags("Users");

            users.MapPost("register", async (CreateUserCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);
            }); 
        }
    }
}
