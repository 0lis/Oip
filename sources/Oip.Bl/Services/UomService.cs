using Mapster;
using Microsoft.Extensions.Logging;
using Oip.Bl.Models;
using Oip.Dal.Entity;
using Oip.Dal.Repositories;

namespace Oip.Bl.Services;

/// <summary>
///     Unit of measurement service
/// </summary>
public class UomService
{
    private readonly ILogger<UomService> _logger;
    private readonly UomRepository _uomRepository;

    /// <summary>
    ///     .ctor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="uomRepository"></param>
    public UomService(ILogger<UomService> logger, UomRepository uomRepository)
    {
        _logger = logger;
        _uomRepository = uomRepository;
    }

    /// <summary>
    ///     Get all UOMs
    /// </summary>
    /// <returns></returns>
    public IEnumerable<UomModel> GetAll()
    {
        return _uomRepository.ToList().Select(x => x.Adapt<UomModel>()).ToList();
    }

    /// <summary>
    ///     Update or insert UOM
    /// </summary>
    /// <param name="uom"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Upsert(UomModel uom)
    {
        if (uom == null) throw new ArgumentNullException(nameof(uom));
        _uomRepository.Upsert(uom.Adapt<Uom>());
    }

    /// <summary>
    ///     Delete UOM
    /// </summary>
    /// <param name="uom"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Delete(UomModel uom)
    {
        if (uom == null) throw new ArgumentNullException(nameof(uom));
        _uomRepository.Delete(uom.Adapt<Uom>());
    }
}