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
    public class DeleteMessageCommandHandler(IRepository<Message> repository , IMapper mapper , IUnitOfWork unitOfWork) : IRequestHandler<DeleteMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await repository.GetByIdAsync(request.Id);
            if (message is null) 
            {
                return BaseResult<object>.NotFound("Message not found");
            }
            repository.DeleteAsync(message);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Message deleted duccessfully");
        }
    }
}
