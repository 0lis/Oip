using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiScope;

public class ApiScopeDeletedEvent : AuditEvent
{
    public ApiScopeDeletedEvent(ApiScopeDto apiScope)
    {
        ApiScope = apiScope;
    }

    public ApiScopeDto ApiScope { get; set; }
}