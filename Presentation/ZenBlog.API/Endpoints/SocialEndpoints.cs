using Azure;
using MediatR;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;

namespace ZenBlog.API.Endpoints
{
    public static class SocialEndpoints
    {
         public static void RegisterSocialEndpoints(this IEndpointRouteBuilder app)
         {
            var socials = app.MapGroup("/api/socials").WithTags("Socials");

            socials.MapGet("/", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAllSocialsQuery());
                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
            socials.MapGet("/{id}", async (IMediator mediator, Guid id) =>
            {
                var response = await mediator.Send(new GetSocialByIdQuery { Id = id });
                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
            socials.MapPost(string.Empty, async (IMediator mediator, CreateSocialCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
            socials.MapPatch("/{id}", async (IMediator mediator,UpdateSocialCommand command) =>
            {
                var response = await mediator.Send(command);

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
            socials.MapDelete("/{id}", async (IMediator mediator, Guid id) =>
            {
                var response = await mediator.Send(new DeleteSocialCommand { Id = id });

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
        }
    }
}
