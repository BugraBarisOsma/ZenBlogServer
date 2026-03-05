using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Results;

namespace ZenBlog.Application.Features.Socials.Queries
{
    public class GetSocialByIdQuery : IRequest<BaseResult<GetSocialByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
