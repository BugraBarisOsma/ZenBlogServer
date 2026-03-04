using MediatR;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Queries;

namespace ZenBlog.API.Endpoints
{
    public static class SubCommentEndpoints
    {
        public static void RegisterSubCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var subComments = app.MapGroup("/subComments").WithTags("SubComments");

            subComments.MapPost(string.Empty, async (CreateSubCommentCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });

            subComments.MapPost("/{id}", async (UpdateSubCommentCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });

            subComments.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAllSubcommentsQuery());

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
            subComments.MapGet("/{id}", async (Guid id , IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSubCommentByIdQuery(id));

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
            subComments.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new DeleteSubCommentCommand { Id = id });
                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
        }
    }
}
