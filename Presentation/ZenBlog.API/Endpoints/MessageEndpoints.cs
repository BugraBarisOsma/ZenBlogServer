using Azure;
using MediatR;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;

namespace ZenBlog.API.Endpoints
{
    public static class MessageEndpoints
    {
        public static void RegisterMessageEndpoints(this IEndpointRouteBuilder app)
        {
            var messages = app.MapGroup("/messages").WithTags("Messages");
            messages.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAllMessagesQuery());

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);

            });
            messages.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetMessageByIdQuery { Id = id });

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });

            messages.MapPost(string.Empty, async (CreateMessageCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
            messages.MapPatch("/{id}", async (UpdateMessageCommand request, IMediator mediator) =>
            {
                var response = await mediator.Send(request);

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });

            messages.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new DeleteMessageCommand { Id = id });

                return response.IsSuccess
                   ? Results.Ok(response)
                   : Results.BadRequest(response);
            });
        }
    }
}
