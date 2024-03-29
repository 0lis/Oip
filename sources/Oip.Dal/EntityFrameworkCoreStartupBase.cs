using System;
using Microsoft.EntityFrameworkCore;

namespace Oip.Dal;

public abstract class EntityFrameworkCoreStartupBase
{
    protected abstract string ProviderName { get; }

    public void ConfigureOip(OipOptionsBuilder oip)
    {
    }

    protected virtual string GetDefaultConnectionString()
    {
        throw new Exception($"No connection string specified for the {ProviderName} provider");
    }

    protected abstract void Configure(DbContextOptionsBuilder options, string connectionString);
}