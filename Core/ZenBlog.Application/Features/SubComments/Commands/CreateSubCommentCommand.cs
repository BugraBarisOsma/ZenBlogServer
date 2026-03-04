using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.Json.Serialization;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Commands
{
    public class CreateSubCommentCommand : IRequest<BaseResult<object>>   
    {
        public Guid UserID { get; set; }
        public string? Content { get; set; }
        [JsonIgnore]
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public Guid CommentId { get; set; } 

    }
}
