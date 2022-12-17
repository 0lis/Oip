using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Dtos.Configuration;

namespace Oip.Security.BusinessLogic.Events.ApiScope
{
    public class ApiScopeAddedEvent : AuditEvent
    {
        public ApiScopeDto ApiScope { get; set; }

        public ApiScopeAddedEvent(ApiScopeDto apiScope)
        {
            ApiScope = apiScope;
        }
    }
}