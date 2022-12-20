﻿using Skoruba.AuditLogging.Events;

namespace Oip.Security.Bl.Identity.Events.Identity;

public class UsersRequestedEvent<TUsersDto> : AuditEvent
{
    public UsersRequestedEvent(TUsersDto users)
    {
        Users = users;
    }

    public TUsersDto Users { get; set; }
}