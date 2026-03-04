using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Results
{
    public class GetAllSubCommentsQueryResult : BaseDTO
    {
        public Guid UserID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
    }
}
