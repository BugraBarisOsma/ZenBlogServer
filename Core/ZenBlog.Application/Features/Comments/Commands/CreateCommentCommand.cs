using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Commands
{
    public class CreateCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public DateTime CommentDate { get; set; } = DateTime.UtcNow;
        public Guid BlogId { get; set; }
    }
}
