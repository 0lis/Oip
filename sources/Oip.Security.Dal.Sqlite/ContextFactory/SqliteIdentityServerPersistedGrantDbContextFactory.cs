﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oip.Security.Dal.Common.DbContexts;
using Oip.Security.EntityFramework.Common.DbContexts;

namespace Oip.Security.Dal.Sqlite.ContextFactory;

public class SqliteIdentityServerPersistedGrantDbContextFactory: IDesignTimeDbContextFactory<IdentityServerPersistedGrantDbContext>
{
    public IdentityServerPersistedGrantDbContext CreateDbContext(string[] args)
    { 
        var builder = new DbContextOptionsBuilder<IdentityServerPersistedGrantDbContext>();
        var connectionString = args.Any() ? args[0] : Constants.DefaultConnectionString;
        builder.UseSqlite(connectionString, db => db
            .MigrationsAssembly(typeof(SqliteBaseDbContextFactory<>).Assembly.GetName().Name)
            .MigrationsHistoryTable(Constants.MigrationsHistoryTable));
        return new IdentityServerPersistedGrantDbContext(builder.Options, new());
    }
}