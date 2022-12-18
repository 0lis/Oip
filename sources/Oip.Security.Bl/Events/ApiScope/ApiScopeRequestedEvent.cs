using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiScope;

public class ApiScopeRequestedEvent : AuditEvent
{
    public ApiScopeRequestedEvent(ApiScopeDto apiScopes)
    {
        ApiScopes = apiScopes;
    }

    public ApiScopeDto ApiScopes { get; set; }
}