﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oip.Security.EntityFramework.Common.Constants;
using Oip.Security.EntityFramework.Common.Entities.Identity;
using Oip.Security.EntityFramework.Shared.Entities.Identity;

namespace Oip.Security.EntityFramework.Common.DbContexts;

public class AdminIdentityDbContext : 
    IdentityDbContext<UserIdentity, UserIdentityRole, string, UserIdentityUserClaim,
    UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken>
{
    public const string MigrationsHistoryTable = "AdminIdentityDbContextMigrationHistory";

    public AdminIdentityDbContext(DbContextOptions<AdminIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        ConfigureIdentityContext(builder);
    }

    private void ConfigureIdentityContext(ModelBuilder builder)
    {
        builder.Entity<UserIdentityRole>().ToTable(TableConsts.IdentityRoles);
        builder.Entity<UserIdentityRoleClaim>().ToTable(TableConsts.IdentityRoleClaims);
        builder.Entity<UserIdentityUserRole>().ToTable(TableConsts.IdentityUserRoles);
        builder.Entity<UserIdentity>().ToTable(TableConsts.IdentityUsers);
        builder.Entity<UserIdentityUserLogin>().ToTable(TableConsts.IdentityUserLogins);
        builder.Entity<UserIdentityUserClaim>().ToTable(TableConsts.IdentityUserClaims);
        builder.Entity<UserIdentityUserToken>().ToTable(TableConsts.IdentityUserTokens);
    }
}