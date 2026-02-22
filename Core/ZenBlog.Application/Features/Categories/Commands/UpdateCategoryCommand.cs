using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands
{
    public record UpdateCategoryCommand(Guid id, string CategoryName) : IRequest<BaseResult<bool>>
    {
    }
}
