using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiResource;

public class ApiResourcesRequestedEvent : AuditEvent
{
    public ApiResourcesRequestedEvent(ApiResourcesDto apiResources)
    {
        ApiResources = apiResources;
    }

    public ApiResourcesDto ApiResources { get; set; }
}