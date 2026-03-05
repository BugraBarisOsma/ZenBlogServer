using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Results
{
    public class GetAllContactInfosQueryResult :BaseDTO
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MapUrl { get; set; }
    }
}
