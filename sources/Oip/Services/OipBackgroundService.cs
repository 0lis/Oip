namespace Oip.Services;

/// <summary>
///     Opl Background Service
/// </summary>
public class OipBackgroundService : BackgroundService
{
    private readonly ILogger<OipBackgroundService> _logger;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"></param>
    public OipBackgroundService(ILogger<OipBackgroundService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    private static Task DoWork(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }

    #region BackgroundService

    /// <summary>
    ///     Execute Async Work
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Consume Scoped Service Hosted Service running.");
        await DoWork(stoppingToken);
    }

    /// <summary>
    ///     Stop work async
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Consume Scoped Service Hosted Service is stopping.");
        await base.StopAsync(stoppingToken);
    }

    #endregion
}