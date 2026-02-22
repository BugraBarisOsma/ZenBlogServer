using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Results
{
    public class GetCategoryByIdQueryResult : BaseDTO
    {
        public string CategoryName { get; set; }
    }
}
