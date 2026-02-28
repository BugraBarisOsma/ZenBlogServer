using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class GetBlogByIdQueryHandler(IRepository<Blog> repository, IMapper mapper) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);
            if (result is null)
            {
                return BaseResult<GetBlogByIdQueryResult>.NotFound($"Blog with id {request.Id} not found.");
            }
            var blog = mapper.Map<GetBlogByIdQueryResult>(result);

            return BaseResult<GetBlogByIdQueryResult>.Success(blog);

        }
    }
}
