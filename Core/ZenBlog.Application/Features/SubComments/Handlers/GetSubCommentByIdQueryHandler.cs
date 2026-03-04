using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class GetSubCommentByIdQueryHandler(IRepository<SubComment> repository, IMapper mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(request.Id);
            if (result is null)
            {
                return BaseResult<GetSubCommentByIdQueryResult>.NotFound($"SubComment with id {request.Id} not found.");
            }

            var subComment = mapper.Map<GetSubCommentByIdQueryResult>(result);
            return BaseResult<GetSubCommentByIdQueryResult>.Success(subComment);
        }
    }
}
