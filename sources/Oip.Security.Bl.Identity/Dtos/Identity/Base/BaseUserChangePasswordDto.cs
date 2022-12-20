using Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.Bl.Identity.Dtos.Identity.Base;

public class BaseUserChangePasswordDto<TUserId> : IBaseUserChangePasswordDto
{
    public TUserId UserId { get; set; }

    object IBaseUserChangePasswordDto.UserId => UserId;
}