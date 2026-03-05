using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class GetSocialByIdQueryHandler(IRepository<Social> repository , IMapper mapper) : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialByIdQueryResult>> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);
            if (result is null)
            {
                return BaseResult<GetSocialByIdQueryResult>.NotFound($"Social with id {request.Id} not found.");
            }
            var mappedResult = mapper.Map<GetSocialByIdQueryResult>(result);    
            return BaseResult<GetSocialByIdQueryResult>.Success(mappedResult);
        }
    }
}
