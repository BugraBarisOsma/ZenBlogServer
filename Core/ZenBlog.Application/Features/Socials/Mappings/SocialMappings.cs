using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Mappings
{
    public class SocialMappings : Profile
    {
        public SocialMappings()
        {
            CreateMap<Social,GetAllSocialsQueryResult>().ReverseMap();
            CreateMap<Social,GetSocialByIdQueryResult>().ReverseMap();

            CreateMap<CreateSocialCommand, Social>().ReverseMap();
            CreateMap<DeleteSocialCommand, Social>().ReverseMap();
            CreateMap<UpdateSocialCommand, Social>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
