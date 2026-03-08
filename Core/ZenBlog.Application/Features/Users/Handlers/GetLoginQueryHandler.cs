using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Users.Queries;
using ZenBlog.Application.Features.Users.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers
{
    public class GetLoginQueryHandler(UserManager<AppUser> userManager , IJwtService jwtService , IMapper mapper) : IRequestHandler<GetLoginQuery, BaseResult<GetLoginQueryResult>>
    {
        public async Task<BaseResult<GetLoginQueryResult>> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BaseResult<GetLoginQueryResult>.NotFound("User Not Found");
            }

            var result = await userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                return BaseResult<GetLoginQueryResult>.Failure("Invalid Password");
            }
            var userResult = mapper.Map<GetUsersQueryResult>(user);

            var response = await jwtService.GenerateTokenAsync(userResult);
            if (response == null)
            {
                return BaseResult<GetLoginQueryResult>.Failure("Login Failed");
            }

            return BaseResult<GetLoginQueryResult>.Success(response);

        }
    }
}
