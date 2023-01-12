using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oip.Dal;

namespace Oip.Bl.Controllers;

/// <summary>
///     In current time architecture not stable
/// </summary>
[ApiController]
[Route("api/oip")]
public class OipController : ControllerBase
{
    private readonly ILogger<OipController> _logger;
    private readonly OipContext _oipContext;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="serviceProvider"></param>
    /// <param name="oipContext"></param>
    public OipController(ILogger<OipController> logger, IServiceProvider serviceProvider, OipContext oipContext)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _oipContext = oipContext;
    }
}