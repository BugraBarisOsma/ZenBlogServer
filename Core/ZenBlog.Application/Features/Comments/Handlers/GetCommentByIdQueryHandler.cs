using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class GetCommentByIdQueryHandler(IRepository<Comment> repository,IMapper mapper) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
           var result= await repository.GetByIdAsync(request.CommentId);
           if(result is null)
           {
                return BaseResult<GetCommentByIdQueryResult>.NotFound("Comment not found");
           }
           var comment = mapper.Map<GetCommentByIdQueryResult>(result);
           return BaseResult<GetCommentByIdQueryResult>.Success(comment);

        }
    }
}
