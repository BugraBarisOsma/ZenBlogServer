using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Results;

namespace ZenBlog.Application.Features.Categories.Results
{
    public class GetCategoryBySlugQueryResult : BaseDTO
    {
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public IList<GetBlogsByCategoryIdQueryResult> Blogs { get; set; }
    }
}
