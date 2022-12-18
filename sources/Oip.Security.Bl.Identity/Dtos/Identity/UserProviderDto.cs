﻿using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Base;
using Oip.Security.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Oip.Security.BusinessLogic.Identity.Dtos.Identity;

public class UserProviderDto<TKey> : BaseUserProviderDto<TKey>, IUserProviderDto
{
    public string UserName { get; set; }

    public string ProviderKey { get; set; }

    public string LoginProvider { get; set; }

    public string ProviderDisplayName { get; set; }
}