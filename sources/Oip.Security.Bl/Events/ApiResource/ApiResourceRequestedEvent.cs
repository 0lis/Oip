using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiResource;

public class ApiResourceRequestedEvent : AuditEvent
{
    public ApiResourceRequestedEvent(int apiResourceId, ApiResourceDto apiResource)
    {
        ApiResourceId = apiResourceId;
        ApiResource = apiResource;
    }

    public int ApiResourceId { get; set; }
    public ApiResourceDto ApiResource { get; set; }
}