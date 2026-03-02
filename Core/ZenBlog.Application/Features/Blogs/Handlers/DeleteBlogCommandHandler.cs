using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class DeleteBlogCommandHandler(IRepository<Blog> repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteBlogCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await repository.GetByIdAsync(request.Id);
            if (blog == null)
            {
                return BaseResult<bool>.NotFound($"Blog with id {request.Id} not found.");
            }

            repository.DeleteAsync(blog);
            var result = await unitOfWork.SaveChangesAsync();

            return result
                ? BaseResult<bool>.Success(true)
                : BaseResult<bool>.Failure("Failed to delete the blog.");
        }
    }
}
