﻿using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class RoleRequestedEvent<TRoleDto> : AuditEvent
{
    public RoleRequestedEvent(TRoleDto role)
    {
        Role = role;
    }

    public TRoleDto Role { get; set; }
}