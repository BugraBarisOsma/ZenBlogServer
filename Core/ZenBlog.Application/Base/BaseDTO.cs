using System;
using System.Collections.Generic;
using System.Text;

namespace ZenBlog.Application.Base
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
