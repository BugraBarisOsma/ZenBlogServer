using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Results
{
    public class GetCategoryQueryResult : Base.BaseDTO
    {
        public string CategoryName { get; set; }
        //public IList<GetBlogQueryResult> Blogs { get; set; }
    }
}
