using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.IdentityResource;

public class IdentityResourcePropertiesRequestedEvent : AuditEvent
{
    public IdentityResourcePropertiesRequestedEvent(IdentityResourcePropertiesDto identityResourceProperties)
    {
        IdentityResourceProperties = identityResourceProperties;
    }

    public IdentityResourcePropertiesDto IdentityResourceProperties { get; set; }
}