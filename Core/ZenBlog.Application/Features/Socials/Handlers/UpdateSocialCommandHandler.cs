using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class UpdateSocialCommandHandler(IRepository<Social> repository , IMapper mapper , IUnitOfWork unitOfWork) : IRequestHandler<UpdateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) 
            {
                return BaseResult<object>.NotFound($"Social with id {request.Id} not found.");
            }
            mapper.Map(request, entity);
            repository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Social updated successfully");
        }
    }
}
