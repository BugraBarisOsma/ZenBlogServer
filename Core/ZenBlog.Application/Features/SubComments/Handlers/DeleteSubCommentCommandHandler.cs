using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class DeleteSubCommentCommandHandler(IRepository<SubComment> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<DeleteSubCommentCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteSubCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null)
            {
                return BaseResult<bool>.NotFound($"Blog with id {request.Id} not found.");
            }
            repository.DeleteAsync(entity);
            var result = await unitOfWork.SaveChangesAsync();

            return result
                ? BaseResult<bool>.Success(true)
                : BaseResult<bool>.Failure("Failed to delete the blog.");
        }
    }
}
