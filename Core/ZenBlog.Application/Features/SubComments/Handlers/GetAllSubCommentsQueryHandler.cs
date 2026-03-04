using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Results;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class GetAllSubCommentsQueryHandler(IRepository<SubComment> repository, IMapper mapper) : IRequestHandler<GetAllSubcommentsQuery, BaseResult<List<GetAllSubCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetAllSubCommentsQueryResult>>> Handle(GetAllSubcommentsQuery request, CancellationToken cancellationToken)
        {
           var values= await repository.GetAllAsync();
           var subComments = mapper.Map<List<GetAllSubCommentsQueryResult>>(values);
           return BaseResult<List<GetAllSubCommentsQueryResult>>.Success(subComments);
        }
    }
}
