﻿using Skoruba.AuditLogging.Events;

namespace Oip.Security.Bl.Identity.Events.Identity;

public class UserProvidersDeletedEvent<TUserProviderDto> : AuditEvent
{
    public UserProvidersDeletedEvent(TUserProviderDto provider)
    {
        Provider = provider;
    }

    public TUserProviderDto Provider { get; set; }
}