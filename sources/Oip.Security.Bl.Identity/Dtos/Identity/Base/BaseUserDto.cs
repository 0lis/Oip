using System.Collections.Generic;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity.Base;

public class BaseUserDto<TUserId> : IBaseUserDto
{
    public TUserId Id { get; set; }

    public bool IsDefaultId()
    {
        return EqualityComparer<TUserId>.Default.Equals(Id, default);
    }

    object IBaseUserDto.Id => Id;
}