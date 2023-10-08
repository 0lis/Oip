namespace Oip.Bl.Models;

/// <summary>
///     UOM model
/// </summary>
public class UomModel
{
    /// <summary>
    ///     Identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Formula
    /// </summary>
    public string Formula { get; set; } = string.Empty;

    /// <summary>
    ///     Base UOM
    /// </summary>
    public int? BaseUomId { get; set; }
}