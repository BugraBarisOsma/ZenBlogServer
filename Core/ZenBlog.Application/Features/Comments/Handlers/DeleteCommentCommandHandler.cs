using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class DeleteCommentCommandHandler(IRepository<Comment> repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCommentCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {

            var comment = await repository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                return BaseResult<bool>.NotFound($"Comment with id {request.Id} not found.");
            }

            repository.DeleteAsync(comment);
            var result = await unitOfWork.SaveChangesAsync();

            return result
                   ? BaseResult<bool>.Success(true)
                   : BaseResult<bool>.Failure("Failed to delete the blog."); 
        }
    }
}
