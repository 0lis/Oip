﻿using Oip.Security.Bl.Identity.Dtos.Grant;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.Bl.Identity.Events.PersistedGrant;

public class PersistedGrantsIdentityByUserRequestedEvent : AuditEvent
{
    public PersistedGrantsIdentityByUserRequestedEvent(PersistedGrantsDto persistedGrants)
    {
        PersistedGrants = persistedGrants;
    }

    public PersistedGrantsDto PersistedGrants { get; set; }
}