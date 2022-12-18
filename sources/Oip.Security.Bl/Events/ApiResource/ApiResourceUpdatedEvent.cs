using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiResource;

public class ApiResourceUpdatedEvent : AuditEvent
{
    public ApiResourceUpdatedEvent(ApiResourceDto originalApiResource, ApiResourceDto apiResource)
    {
        OriginalApiResource = originalApiResource;
        ApiResource = apiResource;
    }

    public ApiResourceDto OriginalApiResource { get; set; }
    public ApiResourceDto ApiResource { get; set; }
}