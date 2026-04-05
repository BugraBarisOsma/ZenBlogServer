using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category,GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category,CreateCategoryCommand>().ReverseMap();
            CreateMap<Category,GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category,GetCategoryBySlugQueryResult>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

        }
    }
}
