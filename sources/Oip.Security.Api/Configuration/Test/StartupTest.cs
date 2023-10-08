﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oip.Security.Api.Helpers;
using Oip.Security.Api.Middlewares;
using Oip.Security.Dal.Common.Entities.Identity;
using Oip.Security.Dal.DbContexts;
using Oip.Security.Dal.Shared.Entities.Identity;

namespace Oip.Security.Api.Configuration.Test;

public class StartupTest : Startup
{
    public StartupTest(IWebHostEnvironment env, IConfiguration configuration) : base(env, configuration)
    {
    }

    public override void RegisterDbContexts(IServiceCollection services)
    {
        services
            .RegisterDbContextsStaging<AdminIdentityDbContext, IdentityServerConfigurationDbContext,
                IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext,
                IdentityServerDataProtectionDbContext>();
    }

    public override void RegisterAuthentication(IServiceCollection services)
    {
        services
            .AddIdentity<UserIdentity, UserIdentityRole>(options =>
                Configuration.GetSection(nameof(IdentityOptions)).Bind(options))
            .AddEntityFrameworkStores<AdminIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddCookie(JwtBearerDefaults.AuthenticationScheme);
    }

    public override void RegisterAuthorization(IServiceCollection services)
    {
        services.AddAuthorizationPolicies();
    }

    public override void UseAuthentication(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
    }
}