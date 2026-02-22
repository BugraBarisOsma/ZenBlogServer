using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Application.Contracts.Persistence
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetQuery();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity,bool>> filter);
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);

    }
}
