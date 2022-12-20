﻿using Skoruba.AuditLogging.Events;

namespace Oip.Security.Bl.Identity.Events.Identity;

public class UserRequestedEvent<TUserDto> : AuditEvent
{
    public UserRequestedEvent(TUserDto userDto)
    {
        UserDto = userDto;
    }

    public TUserDto UserDto { get; set; }
}