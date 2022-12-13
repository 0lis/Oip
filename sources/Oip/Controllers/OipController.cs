using Microsoft.AspNetCore.Mvc;
using Oip.Dal.Core;
using Oip.Dal.Core.Entity;

namespace Oip.Controllers;

/// <summary>
///     In current time architecture not stable
/// </summary>
[ApiController]
[Route("api/uom")]
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

    /// <summary>
    ///     Get all Uoms
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    public IEnumerable<Uom> GetAll()
    {
        return (from uom in _oipContext.Uoms
            select uom).ToList();
    }

    /// <summary>
    ///     Upsert uom
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost("upsert")]
    public async Task<IActionResult> Upsert(Uom item)
    {
        var uoms = (from uom in _oipContext.Uoms
            where uom.Id == item.Id
            select uom).FirstOrDefault();
        if (uoms == null)
        {
            _oipContext.Uoms.Add(item);
            await _oipContext.SaveChangesAsync();
        }
        else
        {
            _oipContext.Uoms.Update(item);
        }

        return Ok();
    }

    /// <summary>
    ///     Delete uom
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    [HttpPost("delete")]
    public async Task<IActionResult> Delete(Uom item)
    {
        var uoms = (from uom in _oipContext.Uoms
            where uom.Id == item.Id
            select uom).FirstOrDefault();
        if (uoms != null)
        {
            _oipContext.Uoms.Remove(uoms);
            await _oipContext.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException();
        }

        return Ok();
    }
}