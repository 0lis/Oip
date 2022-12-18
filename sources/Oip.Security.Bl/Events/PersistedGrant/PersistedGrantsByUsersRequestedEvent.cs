using Oip.Security.BusinessLogic.Dtos.Grant;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantsByUsersRequestedEvent : AuditEvent
{
    public PersistedGrantsByUsersRequestedEvent(PersistedGrantsDto persistedGrants)
    {
        PersistedGrants = persistedGrants;
    }

    public PersistedGrantsDto PersistedGrants { get; set; }
}