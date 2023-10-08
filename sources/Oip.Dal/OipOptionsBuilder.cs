using Microsoft.Extensions.DependencyInjection;

namespace Oip.Dal;

public abstract class OipOptionsBuilder
{
    protected OipOptionsBuilder(IServiceCollection services)
    {
    }

    public IServiceCollection Services { get; }
}