using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public class DeleteSubCommentCommand : IRequest<BaseResult<bool>>
    {
        public Guid Id { get; set; }
    }
}
