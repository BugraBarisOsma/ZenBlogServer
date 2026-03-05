using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public class DeleteMessageCommand :IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
    }
}
