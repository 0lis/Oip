﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oip.Security.Dal.Common.DbContexts;
using Oip.Security.EntityFramework.Common.DbContexts;

namespace Oip.Security.Dal.Sqlite.ContextFactory;

public class SqliteIdentityServerConfigurationDbContextFactory: IDesignTimeDbContextFactory<IdentityServerConfigurationDbContext>
{
    public IdentityServerConfigurationDbContext CreateDbContext(string[] args)
    { 
        var builder = new DbContextOptionsBuilder<IdentityServerConfigurationDbContext>();
        var connectionString = args.Any() ? args[0] : Constants.DefaultConnectionString;
        builder.UseSqlite(connectionString, db => db
            .MigrationsAssembly(typeof(SqliteBaseDbContextFactory<>).Assembly.GetName().Name)
            .MigrationsHistoryTable(Constants.MigrationsHistoryTable));
        return new IdentityServerConfigurationDbContext(builder.Options, new());
    }
}