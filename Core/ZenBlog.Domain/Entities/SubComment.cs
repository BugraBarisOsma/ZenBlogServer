using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities
{
    public class SubComment : BaseEntity
    {
        public Guid UserID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual AppUser User { get; set; }
    }
}
