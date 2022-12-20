using System.Collections.Generic;
using System.Linq;
using Oip.Security.Bl.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.Bl.Identity.Dtos.Identity;

public class UserProvidersDto<TUserProviderDto, TKey> : UserProviderDto<TKey>, IUserProvidersDto
    where TUserProviderDto : UserProviderDto<TKey>
{
    public UserProvidersDto()
    {
        Providers = new List<TUserProviderDto>();
    }

    public List<TUserProviderDto> Providers { get; set; }

    List<IUserProviderDto> IUserProvidersDto.Providers => Providers.Cast<IUserProviderDto>().ToList();
}