namespace Oip.Bl.Models;

/// <summary>
///     Model for module
/// </summary>
public class ModuleModel
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
    ///     Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Path to web
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    ///     Icon for module
    /// </summary>
    public string Icon { get; set; } = "file";
}