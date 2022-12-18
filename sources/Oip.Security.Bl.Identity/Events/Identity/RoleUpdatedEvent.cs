﻿using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class RoleUpdatedEvent<TRoleDto> : AuditEvent
{
    public RoleUpdatedEvent(TRoleDto originalRole, TRoleDto role)
    {
        OriginalRole = originalRole;
        Role = role;
    }

    public TRoleDto OriginalRole { get; set; }
    public TRoleDto Role { get; set; }
}