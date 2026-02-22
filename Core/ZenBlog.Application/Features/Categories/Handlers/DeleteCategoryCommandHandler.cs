using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class DeleteCategoryCommandHandler(IRepository<Category> repository , IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await repository.GetByIdAsync(request.id);   
            if (category == null)
            {
                return BaseResult<bool>.NotFound($"Category with id {request.id} not found.");
            }

            repository.DeleteAsync(category);
            var result = await unitOfWork.SaveChangesAsync();

            return result 
                ? BaseResult<bool>.Success(result)
                : BaseResult<bool>.Failure("Failed to delete the category.");

        }
    }
}
