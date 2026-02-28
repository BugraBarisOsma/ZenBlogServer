using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Blogs.Commands
{
    public class UpdateBlogCommand : IRequest<BaseResult<object>> 
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? CoverImage { get; set; }
        public string? BlogImage { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
