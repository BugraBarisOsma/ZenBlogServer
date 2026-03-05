using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class UpdateMessageCommandHandler(IRepository<Message> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await repository.GetByIdAsync(request.Id);
            if (message is null)
            {
               return BaseResult<object>.NotFound($"Message with Id {request.Id} not found.");
            }

            mapper.Map(request, message);
            repository.UpdateAsync(message);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(message);
        }
    }
}
