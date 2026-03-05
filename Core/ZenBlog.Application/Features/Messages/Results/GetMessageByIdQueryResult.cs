using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Results
{
    public class GetMessageByIdQueryResult : BaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool IsRead { get; set; }
    }
}
