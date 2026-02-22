using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual IList<SubComment> SubComments { get; set; }
        public virtual AppUser User { get; set; }
        public Guid BlogId { get; set; }
        public virtual Blog Blog { get; set; }

    }
}
