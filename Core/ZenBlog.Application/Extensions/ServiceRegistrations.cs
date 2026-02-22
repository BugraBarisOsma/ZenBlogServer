using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ZenBlog.Application.Behaviors;

namespace ZenBlog.Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}
