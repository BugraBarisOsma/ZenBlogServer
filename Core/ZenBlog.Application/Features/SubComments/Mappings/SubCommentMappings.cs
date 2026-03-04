using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Mappings
{
    public class SubCommentMappings : Profile
    {
        public SubCommentMappings()
        {
            CreateMap<SubComment, GetAllSubCommentsQueryResult>().ReverseMap();
            CreateMap<SubComment, GetSubCommentByIdQueryResult>().ReverseMap();


            CreateMap<SubComment,CreateSubCommentCommand>().ReverseMap();
            CreateMap<SubComment,UpdateSubCommentCommand>().ReverseMap();
            CreateMap<SubComment,DeleteSubCommentCommand>().ReverseMap();

        }
    }
}
