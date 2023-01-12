using Mapster;
using Microsoft.Extensions.Logging;
using Oip.Bl.Models;
using Oip.Dal.Entity;
using Oip.Dal.Repositories;

namespace Oip.Bl.Services;

/// <summary>
///     Module service
/// </summary>
public class ModuleService
{
    private readonly ILogger<ModuleService> _logger;
    private readonly ModuleRepository _moduleRepository;

    /// <summary>
    ///     .ctr
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="moduleRepository"></param>
    public ModuleService(ILogger<ModuleService> logger, ModuleRepository moduleRepository)
    {
        _logger = logger;
        _moduleRepository = moduleRepository;
    }

    /// <summary>
    ///     Get all module
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ModuleModel> GetAll()
    {
        return _moduleRepository.ToList().Select(x => x.Adapt<ModuleModel>()).ToList();
    }

    /// <summary>
    ///     Update module
    /// </summary>
    /// <param name="module"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Upsert(ModuleModel module)
    {
        if (module == null) throw new ArgumentNullException(nameof(module));
        _moduleRepository.Upsert(module.Adapt<Module>());
    }

    /// <summary>
    ///     Delete module
    /// </summary>
    /// <param name="module"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Delete(ModuleModel module)
    {
        if (module == null) throw new ArgumentNullException(nameof(module));
        _moduleRepository.Delete(module.Adapt<Module>());
    }
}