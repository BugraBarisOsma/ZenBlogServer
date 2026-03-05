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
    public class GetMessageByIdQueryHandler(IRepository<Message> repository, IMapper mapper) : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageByIdQueryResult>>
    {
        public async Task<BaseResult<GetMessageByIdQueryResult>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await repository.GetByIdAsync(request.Id);
            if (message == null) 
            {
                 return BaseResult<GetMessageByIdQueryResult>.NotFound($"Message with id {request.Id} not found.");
            }
            var result = mapper.Map<GetMessageByIdQueryResult>(message);
            return BaseResult<GetMessageByIdQueryResult>.Success(result);
        }
    }
}
