﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slowary.Application.Common.Contexts;
using Slowary.Infrastructure.Persistence;

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
                .AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

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