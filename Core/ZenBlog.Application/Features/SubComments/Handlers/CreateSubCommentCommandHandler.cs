using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class CreateSubCommentCommandHandler(IRepository<SubComment> repository,IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = mapper.Map<SubComment>(request);
            await repository.AddAsync(subComment);
            var result = await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(subComment.Id);
        }
    }
}
