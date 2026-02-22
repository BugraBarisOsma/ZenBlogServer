using System;
using System.Collections.Generic;
using System.Text;

namespace ZenBlog.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();

    }
}
