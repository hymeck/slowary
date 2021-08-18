using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Slowary.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddFluentValidation(conf => conf.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
                .AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}