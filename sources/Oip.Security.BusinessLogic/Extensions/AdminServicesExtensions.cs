﻿using Microsoft.EntityFrameworkCore;
using Oip.Security.BusinessLogic.Resources;
using Oip.Security.BusinessLogic.Services;
using Oip.Security.BusinessLogic.Services.Interfaces;
using Oip.Security.EntityFramework.Interfaces;
using Oip.Security.EntityFramework.Repositories;
using Oip.Security.EntityFramework.Repositories.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AdminServicesExtensions
    {
        public static IServiceCollection AddAdminServices<TAdminDbContext>(
            this IServiceCollection services)
            where TAdminDbContext : DbContext, IAdminPersistedGrantDbContext, IAdminConfigurationDbContext, IAdminLogDbContext
        {

            return services.AddAdminServices<TAdminDbContext, TAdminDbContext, TAdminDbContext>();
        }

        public static IServiceCollection AddAdminServices<TConfigurationDbContext, TPersistedGrantDbContext, TLogDbContext>(this IServiceCollection services)
            where TPersistedGrantDbContext : DbContext, IAdminPersistedGrantDbContext
            where TConfigurationDbContext : DbContext, IAdminConfigurationDbContext
            where TLogDbContext : DbContext, IAdminLogDbContext
        {
            //Repositories
            services.AddTransient<IClientRepository, ClientRepository<TConfigurationDbContext>>();
            services.AddTransient<IIdentityResourceRepository, IdentityResourceRepository<TConfigurationDbContext>>();
            services.AddTransient<IApiResourceRepository, ApiResourceRepository<TConfigurationDbContext>>();
            services.AddTransient<IApiScopeRepository, ApiScopeRepository<TConfigurationDbContext>>();
            services.AddTransient<IPersistedGrantRepository, PersistedGrantRepository<TPersistedGrantDbContext>>();
            services.AddTransient<ILogRepository, LogRepository<TLogDbContext>>();

            //Services
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IApiResourceService, ApiResourceService>();
            services.AddTransient<IApiScopeService, ApiScopeService>();
            services.AddTransient<IIdentityResourceService, IdentityResourceService>();
            services.AddTransient<IPersistedGrantService, PersistedGrantService>();
            services.AddTransient<ILogService, LogService>();

            //Resources
            services.AddScoped<IApiResourceServiceResources, ApiResourceServiceResources>();
            services.AddScoped<IApiScopeServiceResources, ApiScopeServiceResources>();
            services.AddScoped<IClientServiceResources, ClientServiceResources>();
            services.AddScoped<IIdentityResourceServiceResources, IdentityResourceServiceResources>();
            services.AddScoped<IPersistedGrantServiceResources, PersistedGrantServiceResources>();

            return services;
        }
    }
}
