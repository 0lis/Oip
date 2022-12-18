using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiScope;

public class ApiScopePropertyAddedEvent : AuditEvent
{
    public ApiScopePropertyAddedEvent(ApiScopePropertiesDto apiScopeProperty)
    {
        ApiScopeProperty = apiScopeProperty;
    }

    public ApiScopePropertiesDto ApiScopeProperty { get; set; }
}