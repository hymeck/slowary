using System.Reflection;
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
                .AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}