using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class GetAllContactInfosQueryHandler(IRepository<ContactInfo> repository ,IMapper mapper) : IRequestHandler<GetAllContactInfosQuery, BaseResult<List<GetAllContactInfosQueryResult>>>
    {
        public async Task<BaseResult<List<GetAllContactInfosQueryResult>>> Handle(GetAllContactInfosQuery request, CancellationToken cancellationToken)
        {
           var result = await repository.GetAllAsync();
           if(result == null || result.Count == 0)
           {
               return BaseResult<List<GetAllContactInfosQueryResult>>.NotFound("No contact info found.");
           }
              var mappedResult = mapper.Map<List<GetAllContactInfosQueryResult>>(result);
              return BaseResult<List<GetAllContactInfosQueryResult>>.Success(mappedResult);
        }
    }
}
