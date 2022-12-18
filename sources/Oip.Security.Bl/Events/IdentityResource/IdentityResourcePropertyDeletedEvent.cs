using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.IdentityResource;

public class IdentityResourcePropertyDeletedEvent : AuditEvent
{
    public IdentityResourcePropertyDeletedEvent(IdentityResourcePropertiesDto identityResourceProperty)
    {
        IdentityResourceProperty = identityResourceProperty;
    }

    public IdentityResourcePropertiesDto IdentityResourceProperty { get; set; }
}