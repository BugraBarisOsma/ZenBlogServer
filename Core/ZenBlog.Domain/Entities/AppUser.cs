using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ZenBlog.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageURL { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<SubComment> SubComments { get; set; }
    }
}
