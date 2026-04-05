using System;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class GetCategoryBySlugQueryHandler(IRepository<Category> repository, IMapper mapper) : IRequestHandler<GetCategoryBySlugQuery, BaseResult<GetCategoryBySlugQueryResult>>
    {
        public async Task<BaseResult<GetCategoryBySlugQueryResult>> Handle(GetCategoryBySlugQuery request, CancellationToken cancellationToken)
        {
            var category = await repository.GetSingleAsync(c => c.Slug == request.Slug);
            if (category == null)
            {
                return BaseResult<GetCategoryBySlugQueryResult>.NotFound($"Category with slug {request.Slug} not found.");
            }
            var response = mapper.Map<GetCategoryBySlugQueryResult>(category);
            return BaseResult<GetCategoryBySlugQueryResult>.Success(response);
        }
    }
}
