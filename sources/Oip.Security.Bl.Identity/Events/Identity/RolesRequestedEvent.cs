﻿using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class RolesRequestedEvent<TRolesDto> : AuditEvent
{
    public RolesRequestedEvent(TRolesDto roles)
    {
        Roles = roles;
    }

    public TRolesDto Roles { get; set; }
}