using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands
{
    public class DeleteCommentCommand : IRequest<BaseResult<bool>>
    {
        public Guid Id { get; set; }
    }
}
