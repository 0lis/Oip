using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.IdentityResource;

public class IdentityResourcesRequestedEvent : AuditEvent
{
    public IdentityResourcesRequestedEvent(IdentityResourcesDto identityResources)
    {
        IdentityResources = identityResources;
    }

    public IdentityResourcesDto IdentityResources { get; }
}