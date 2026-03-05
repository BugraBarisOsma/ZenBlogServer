using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.ContactInfos.Results;

namespace ZenBlog.Application.Features.ContactInfos.Queries
{
    public class GetContactInfoByIdQuery : IRequest<BaseResult<GetContactInfoByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
