using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oip.Bl.Models.Api;
using Oip.Bl.Services;

namespace Oip.Bl.Controllers;

/// <summary>
///     Module controller
/// </summary>
[ApiController]
[Route("api/module")]
public class ModuleController : ControllerBase
{
    private readonly ILogger<OipController> _logger;
    private readonly ModuleService _moduleService;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="moduleService"></param>
    public ModuleController(ILogger<OipController> logger, ModuleService moduleService)
    {
        _logger = logger;
        _moduleService = moduleService;
    }

    /// <summary>
    ///     Get modules
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-all")]
    public List<GetModulesResponse>? GetAll()
    {
        return _moduleService.GetAll().Select(x => x.Adapt<GetModulesResponse>()).ToList();
    }

    /// <summary>
    ///     Add module
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("insert")]
    public IActionResult InsertModule(InsertModuleRequest request)
    {
        _moduleService.Upsert(request);
        return Ok();
    }

    /// <summary>
    ///     Update module
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("update")]
    public IActionResult UpdateModule(UpdateModuleRequest request)
    {
        _moduleService.Upsert(request);
        return Ok();
    }

    /// <summary>
    ///     Delete module
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete("delete")]
    public IActionResult DeleteModule(DeleteModuleRequest request)
    {
        _moduleService.Delete(request);
        return Ok();
    }
}