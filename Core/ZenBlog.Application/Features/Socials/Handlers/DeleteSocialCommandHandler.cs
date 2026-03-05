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
    public class DeleteSocialCommandHandler(IRepository<Social> repository , IMapper mapper , IUnitOfWork unitOfWork) : IRequestHandler<DeleteSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(DeleteSocialCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return BaseResult<object>.NotFound("Social not found.");
            }
            repository.DeleteAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Social deleted succesfully");

        }
    }
}
