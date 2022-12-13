using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oip.Core.Runtime;

namespace Oip.Core.HostedServices;

public class StartupRunnerHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public StartupRunnerHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var startupRunner = scope.ServiceProvider.GetRequiredService<IStartupRunner>();
        await startupRunner.StartupAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}