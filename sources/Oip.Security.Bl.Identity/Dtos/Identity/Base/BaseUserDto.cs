using System.Collections.Generic;
using Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.Bl.Identity.Dtos.Identity.Base;

public class BaseUserDto<TUserId> : IBaseUserDto
{
    public TUserId Id { get; set; }

    public bool IsDefaultId()
    {
        return EqualityComparer<TUserId>.Default.Equals(Id, default);
    }

    object IBaseUserDto.Id => Id;
}