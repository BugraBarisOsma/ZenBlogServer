using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands
{
    public class CreateSocialCommand :  IRequest<BaseResult<object>>
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
