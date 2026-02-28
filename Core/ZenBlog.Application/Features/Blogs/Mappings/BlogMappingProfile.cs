using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile() 
        { 
            CreateMap<Blog,GetBlogsQueryResult>().ReverseMap();  
            CreateMap<Blog,GetBlogByIdQueryResult>().ReverseMap();

            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();

            // Bunu yapmamızın sebebi, UpdateBlogCommand içindeki null olan property'lerin Blog entity'sindeki mevcut değerleri korumasını sağlamak.
            // Yani, eğer UpdateBlogCommand'da bir property null ise, Blog entity'sindeki o property'nin değeri güncellenmeden kalır.
            CreateMap<UpdateBlogCommand, Blog>() .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
