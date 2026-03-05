using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetAllMessagesQueryHandler(IRepository<Message> repository , IMapper mapper) : IRequestHandler<GetAllMessagesQuery, BaseResult<List<GetAllMessagesQueryResult>>>
    {
        public async Task<BaseResult<List<GetAllMessagesQueryResult>>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await repository.GetAllAsync();  
            if (messages == null) 
            {
              return BaseResult<List<GetAllMessagesQueryResult>>.Failure("No messages found");
            }
            var result = mapper.Map<List<GetAllMessagesQueryResult>>(messages);
            return BaseResult<List<GetAllMessagesQueryResult>>.Success(result);
        }
    }
}
