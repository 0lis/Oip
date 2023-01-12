using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oip.Pages;

/// <summary>
///     ErrorModel page
/// </summary>
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class ErrorModel : PageModel
{
    private readonly ILogger<ErrorModel> _logger;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"></param>
    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///     Request Id
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    ///     Show Request Id
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    /// <summary>
    ///     On get
    /// </summary>
    public void OnGet()
    {
        _logger.LogDebug("OnLog");
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}