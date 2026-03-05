using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Messages.Results;

namespace ZenBlog.Application.Features.Messages.Queries
{
    public class GetAllMessagesQuery : IRequest<BaseResult<List<GetAllMessagesQueryResult>>>
    {
    }
}
