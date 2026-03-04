using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Commands
{
    public class UpdateCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }


    }
}
