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
    public class GetContactInfoByIdQueryHandler(IRepository<ContactInfo> repository, IMapper mapper) : IRequestHandler<GetContactInfoByIdQuery, BaseResult<GetContactInfoByIdQueryResult>>
    {
        public async Task<BaseResult<GetContactInfoByIdQueryResult>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new Exception("Contact info not found");
            }
            var contactInfo = mapper.Map<GetContactInfoByIdQueryResult>(result);
            return BaseResult<GetContactInfoByIdQueryResult>.Success(contactInfo);

        }
    }
}
