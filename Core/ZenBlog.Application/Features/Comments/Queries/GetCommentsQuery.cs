using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Results;

namespace ZenBlog.Application.Features.Comments.Queries
{
    public record GetCommentsQuery : IRequest<BaseResult<List<GetCommentsQueryResult>>>
    {
    }
}
