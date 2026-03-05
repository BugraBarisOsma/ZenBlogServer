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
    public class GetAllSocialsQueryHandler(IRepository<Social> repository , IMapper mapper) : IRequestHandler<GetAllSocialsQuery, BaseResult<List<GetAllSocialsQueryResult>>>
    {
        public async Task<BaseResult<List<GetAllSocialsQueryResult>>> Handle(GetAllSocialsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync();
            if (result is null)
            {
                return BaseResult<List<GetAllSocialsQueryResult>>.Failure("No socials found.");
            }
            var mappedResult = mapper.Map<List<GetAllSocialsQueryResult>>(result);
            return BaseResult<List<GetAllSocialsQueryResult>>.Success(mappedResult);
        }
    }
}
