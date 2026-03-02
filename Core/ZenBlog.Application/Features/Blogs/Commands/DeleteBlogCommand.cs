using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Commands
{
    public class DeleteBlogCommand : IRequest<BaseResult<bool>>
    {
        public Guid Id { get; set; }
    }
}
