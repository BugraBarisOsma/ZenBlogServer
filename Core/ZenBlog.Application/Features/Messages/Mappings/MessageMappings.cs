using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Mappings
{
    public class MessageMappings : Profile
    {
        public MessageMappings()
        {
            CreateMap<Message, GetAllMessagesQueryResult>().ReverseMap();
            CreateMap<Message, GetMessageByIdQueryResult>().ReverseMap();

            CreateMap<Message, CreateMessageCommand>().ReverseMap();
            CreateMap<UpdateMessageCommand, Message>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
