using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiScope;

public class ApiScopePropertyRequestedEvent : AuditEvent
{
    public ApiScopePropertyRequestedEvent(int apiScopePropertyId, ApiScopePropertiesDto apiScopeProperty)
    {
        ApiScopePropertyId = apiScopePropertyId;
        ApiScopeProperty = apiScopeProperty;
    }

    public int ApiScopePropertyId { get; set; }

    public ApiScopePropertiesDto ApiScopeProperty { get; set; }
}