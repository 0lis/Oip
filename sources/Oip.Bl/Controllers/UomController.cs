using Indusoft.IntegrationService.Controllers.Api;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oip.Bl.Models.Api;
using Oip.Bl.Services;

namespace Oip.Bl.Controllers;

/// <summary>
/// Uom controller
/// </summary>
[ApiController]
[Route("api/uom")]
public class UomController : ControllerBase
{
    private readonly ILogger<OipController> _logger;
    private readonly UomService _uomService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="uomService"></param>
    public UomController(ILogger<OipController> logger, UomService uomService)
    {
        _logger = logger;
        _uomService = uomService;
    }

    /// <summary>
    /// Get Uoms
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    public GridResponse<GetUomResponse> GetAll()
    {
        var data = _uomService.GetAll().Select(x => x.Adapt<GetUomResponse>()).ToList();
        return new GridResponse<GetUomResponse>()
        {
            Data = data,
            TotalCount = data.Count
        };
    }

    /// <summary>
    /// Add Uom
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("insert")]
    public IActionResult InsertUom(InsertUomRequest request)
    {
        _uomService.Upsert(request);
        return Ok();
    }

    /// <summary>
    /// Update module
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("update")]
    public IActionResult UpdateUom(UpdateUomRequest request)
    {
        _uomService.Upsert(request);
        return Ok();
    }

    /// <summary>
    /// Delete module
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete("delete")]
    public IActionResult DeleteUom(DeleteUomRequest request)
    {
        _uomService.Delete(request);
        return Ok();
    }
}