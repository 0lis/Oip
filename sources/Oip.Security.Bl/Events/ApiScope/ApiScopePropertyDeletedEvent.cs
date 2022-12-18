using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiScope;

public class ApiScopePropertyDeletedEvent : AuditEvent
{
    public ApiScopePropertyDeletedEvent(ApiScopePropertiesDto apiScopeProperty)
    {
        ApiScopeProperty = apiScopeProperty;
    }

    public ApiScopePropertiesDto ApiScopeProperty { get; set; }
}