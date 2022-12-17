using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Dtos.Configuration;

namespace Oip.Security.BusinessLogic.Events.ApiScope
{
    public class ApiScopeDeletedEvent : AuditEvent
    {
        public ApiScopeDto ApiScope { get; set; }

        public ApiScopeDeletedEvent(ApiScopeDto apiScope)
        {
            ApiScope = apiScope;
        }
    }
}