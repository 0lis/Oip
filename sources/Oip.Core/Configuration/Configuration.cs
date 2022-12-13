namespace Oip.Core.Configuration;

/// <summary>
///     Configuration model
/// </summary>
public class OipConfiguration
{
    /// <summary>
    ///     Static instance
    /// </summary>
    public static OipConfiguration Configuration { get; } = new();

    /// <summary>
    ///     Storage type
    /// </summary>
    public string Storage { get; set; } = string.Empty;

    /// <summary>
    ///     Connection string
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
}