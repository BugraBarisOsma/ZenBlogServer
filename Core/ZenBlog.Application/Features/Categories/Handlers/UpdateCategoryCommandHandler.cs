using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> repository , IMapper mapper , IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            repository.UpdateAsync(category);
            var response = await unitOfWork.SaveChangesAsync();

            return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Failure("Category couldn't be updated");
        }
    }
}
