using MediatR;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Queries;

namespace ZenBlog.API.Endpoints
{
    public static class ContactInfoEndpoints
    {
        public static void RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfos = app.MapGroup("/contactInfos").WithTags("ContactInfos");

            contactInfos.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAllContactInfosQuery());

                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            contactInfos.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetContactInfoByIdQuery { Id = id });

                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            contactInfos.MapPost(string.Empty, async (CreateContactInfoCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            contactInfos.MapPatch(string.Empty, async (UpdateContactInfoCommand request, IMediator mediator) =>
            {
                var response = await mediator.Send(request);

                return response.IsSuccess
                    ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
        }
    }
}
