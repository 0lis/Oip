using Oip.Security.BusinessLogic.Identity.Dtos.Grant;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantsIdentityByUsersRequestedEvent : AuditEvent
{
    public PersistedGrantsIdentityByUsersRequestedEvent(PersistedGrantsDto persistedGrants)
    {
        PersistedGrants = persistedGrants;
    }

    public PersistedGrantsDto PersistedGrants { get; set; }
}