using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Mappings
{
    public class ContactInfosMappings : Profile
    {
        public ContactInfosMappings()
        {
            CreateMap<ContactInfo, GetContactInfoByIdQueryResult>().ReverseMap();
            CreateMap<ContactInfo, GetAllContactInfosQueryResult>().ReverseMap();

            CreateMap<ContactInfo, CreateContactInfoCommand>().ReverseMap();
            CreateMap<UpdateContactInfoCommand, ContactInfo>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
