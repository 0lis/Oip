﻿using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class UserClaimsSavedEvent<TUserClaimsDto> : AuditEvent
{
    public UserClaimsSavedEvent(TUserClaimsDto claims)
    {
        Claims = claims;
    }

    public TUserClaimsDto Claims { get; set; }
}