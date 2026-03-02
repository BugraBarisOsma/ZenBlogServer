using Azure;
using MediatR;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Queries;

namespace ZenBlog.API.Endpoints
{
    public static class CommentEndpoints
    {
        public static void RegisterCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("/api/comments").WithTags("Comments");

            comments.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCommentsQuery());

                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);

            });
            comments.MapPost(string.Empty, async (CreateCommentCommand comment,IMediator mediator) =>
            { 
                var response = await mediator.Send(comment);

                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);

            });
            comments.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCommentByIdQuery(id));

                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
        }
    }
}
