using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Results;

namespace ZenBlog.Application.Features.Categories.Queries
{
    public class GetCategoryBySlugQuery : IRequest<BaseResult<GetCategoryBySlugQueryResult>>
    {
        public string Slug { get; set; }
    }
}
