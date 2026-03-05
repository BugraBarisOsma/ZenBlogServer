using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = await repository.GetByIdAsync(request.Id);
            if (contactInfo == null)
            {
                return BaseResult<object>.Failure("Contact Info not found");
            }

            mapper.Map(request, contactInfo);
            repository.UpdateAsync(contactInfo);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Contact Info updated successfully");
        }
    }
}
