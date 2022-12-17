using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Dtos.Configuration;

namespace Oip.Security.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourcePropertyRequestedEvent : AuditEvent
    {
        public IdentityResourcePropertiesDto IdentityResourceProperties { get; set; }

        public IdentityResourcePropertyRequestedEvent(IdentityResourcePropertiesDto identityResourceProperties)
        {
            IdentityResourceProperties = identityResourceProperties;
        }
    }
}