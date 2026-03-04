using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class UpdateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await repository.GetByIdAsync(request.Id);
            if (comment is null)
                return BaseResult<object>.Failure("Blog not found");

            mapper.Map(request, comment);
            repository.UpdateAsync(comment);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog updated successfully");
        }
    }
}
