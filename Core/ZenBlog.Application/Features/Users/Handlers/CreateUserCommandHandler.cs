using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper) : IRequestHandler<CreateUserCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<AppUser>(request);
            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Failure(result.Errors);
            }
                return BaseResult<object>.Success(result);
        }
    }
}
