using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, GetCommentsQueryResult>().ReverseMap();
            CreateMap<Comment, GetCommentByIdQueryResult>().ReverseMap();

            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
        }
    }
}
