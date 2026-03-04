using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public class UpdateSubCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }

    }
}
