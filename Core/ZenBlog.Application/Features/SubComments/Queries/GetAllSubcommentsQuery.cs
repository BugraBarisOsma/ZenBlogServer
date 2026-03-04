using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.SubComments.Results;

namespace ZenBlog.Application.Features.SubComments.Queries
{
    public record GetAllSubcommentsQuery : IRequest<BaseResult<List<GetAllSubCommentsQueryResult>>>
    {
    }
}
