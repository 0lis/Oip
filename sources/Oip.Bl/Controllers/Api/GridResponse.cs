namespace Indusoft.IntegrationService.Controllers.Api;

public class GridResponse<T>
{
    public List<T>? Data { get; set; }
    public int? TotalCount { get; set; }
    public int? Summary { get; set; }
    public int? GroupCount { get; set; }
}