using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiScope;

public class ApiScopesRequestedEvent : AuditEvent
{
    public ApiScopesRequestedEvent(ApiScopesDto apiScope)
    {
        ApiScope = apiScope;
    }

    public ApiScopesDto ApiScope { get; set; }
}