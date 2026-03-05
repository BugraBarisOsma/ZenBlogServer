using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Results
{
    public class GetSocialByIdQueryResult :  BaseDTO
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
