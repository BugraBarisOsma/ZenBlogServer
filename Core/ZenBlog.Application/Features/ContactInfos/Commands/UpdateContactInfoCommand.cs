using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.ContactInfos.Commands
{
    public class UpdateContactInfoCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? MapUrl { get; set; }
    }
}
