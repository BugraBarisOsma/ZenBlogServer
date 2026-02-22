using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands
{
    public record DeleteCategoryCommand(Guid id) : IRequest<BaseResult<bool>>
    {
    }
}
