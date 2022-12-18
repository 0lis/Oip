using System.Collections.Generic;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

public interface IUserProvidersDto : IUserProviderDto
{
    List<IUserProviderDto> Providers { get; }
}