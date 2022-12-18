using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oip.Security.Dal.Common.DbContexts;

namespace Oip.Security.Dal.Sqlite.ContextFactory;

public class SqliteBaseDbContextFactory<TDbContext>: IDesignTimeDbContextFactory<TDbContext> where TDbContext : DbContext
{
    public TDbContext CreateDbContext(string[] args)
    { 
        var builder = new DbContextOptionsBuilder<TDbContext>();
        var connectionString = args.Any() ? args[0] : Constants.DefaultConnectionString;
        builder.UseSqlite(connectionString, db => db
            .MigrationsAssembly(typeof(SqliteBaseDbContextFactory<>).Assembly.GetName().Name)
            .MigrationsHistoryTable(Constants.MigrationsHistoryTable));
        return (TDbContext)Activator.CreateInstance(typeof(TDbContext), builder.Options);
    }
}
