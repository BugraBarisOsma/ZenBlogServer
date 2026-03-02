using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Results;
using ZenBlog.Application.Features.Users.Results;

namespace ZenBlog.Application.Features.Comments.Results
{
    public class GetCommentByIdQueryResult : BaseDTO
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        //public virtual IList<SubComment> SubComments { get; set; }
        public GetUsersQueryResult User { get; set; }
        public Guid BlogId { get; set; }
        public GetBlogsQueryResult Blog { get; set; }
    }
}
