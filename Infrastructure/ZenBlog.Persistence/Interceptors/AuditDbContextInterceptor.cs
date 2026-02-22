using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Persistence.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, BaseEntity>> Behaviors = new() 
        { 
            { 
             EntityState.Added , AddedBehavior
            },

            {
             EntityState.Modified, ModifiedBehavior
            }
        };

        private static void AddedBehavior(DbContext context, BaseEntity entity)
        {
            context.Entry(entity).Property(x=>x.UpdatedAt).IsModified = false;
            entity.CreatedAt = DateTime.UtcNow;
        }
        private static void ModifiedBehavior(DbContext context, BaseEntity entity)
        {
            context.Entry(entity).Property(x => x.CreatedAt).IsModified = false;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is not BaseEntity baseEntity)
                {
                    continue;
                }

                if(entry.State is not EntityState.Added and not EntityState.Modified)
                {
                    continue;
                }

                Behaviors[entry.State](eventData.Context, baseEntity);
            }
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
