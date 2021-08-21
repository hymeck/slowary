using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slowary.Application.Common.Dao.Signs;
using Slowary.Application.Services;
using Slowary.Infrastructure.Persistence;
using Slowary.Infrastructure.Persistence.Dao.Signs;
using Slowary.Infrastructure.Services;

namespace Slowary.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            IDbConfiguration dbConf = new MysqlConfiguration();

            services
                .AddApplicationDbContext(dbConf.GetOptions(configuration))
                // todo: make in a generic way using reflection? like AddServices(Assembly.GetExecutingAssembly())
                .AddScoped<IAsyncSignAdder, EfAsyncSignAdder>()
                .AddScoped<IAsyncSignFinder, EfAsyncSignFinder>()
                .AddScoped<IAsyncSignUpdater, EfAsyncSignUpdater>()
                .AddScoped<IAsyncSignDeleter, EfAsyncSignDeleter>()
                .AddScoped<IAsyncSignPaginator, EfAsyncSignPaginator>();

            services
                .AddSingleton<ISignPaginationConfProvider, SignPaginationConfProvider>();

            return services;
        }

        private static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder> optionsAction) =>
            services.AddDbContext<ApplicationDbContext>(optionsAction);
    }

    internal interface IDbConfiguration
    {
        public Action<DbContextOptionsBuilder> GetOptions(IConfiguration configuration);
    }

    internal class MysqlConfiguration : IDbConfiguration
    {
        private string GetVersionString(IConfiguration configuration) => configuration["dbVersionString:mysql"];

        private MySqlServerVersion GetMySqlServerVersion(IConfiguration configuration) =>
            new(GetVersionString(configuration));

        public Action<DbContextOptionsBuilder> GetOptions(IConfiguration configuration) => options =>
            options.UseMySql(configuration.GetConnectionString("default"),
                GetMySqlServerVersion(configuration));
    }
}