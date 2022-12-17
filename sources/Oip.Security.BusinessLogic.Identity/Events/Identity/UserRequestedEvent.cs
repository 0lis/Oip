using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity
{
    public class UserRequestedEvent<TUserDto> : AuditEvent
    {
        public TUserDto UserDto { get; set; }

        public UserRequestedEvent(TUserDto userDto)
        {
            UserDto = userDto;
        }
    }
}