using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class UpdateBlogCommandHandler(IRepository<Blog> repository,IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await repository.GetByIdAsync(request.Id);
            if (blog is null)
                return BaseResult<object>.Failure("Blog not found");

            // Sadece dolu gelen alanlar map edilecek
            mapper.Map(request, blog);
            repository.UpdateAsync(blog);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog updated successfully");


        }
    }
}
