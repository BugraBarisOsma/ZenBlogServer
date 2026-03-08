using System;
using System.Collections.Generic;
using System.Text;
using ZenBlog.Application.Features.Users.Results;

namespace ZenBlog.Application.Contracts.Persistence
{
    public interface IJwtService
    {
        Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result);
    }
}
