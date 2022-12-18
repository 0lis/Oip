﻿using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Oip.Security.BusinessLogic.Identity.Dtos.Grant;
using Oip.Security.EntityFramework.Entities;
using Oip.Security.EntityFramework.Extensions.Common;

namespace Oip.Security.BusinessLogic.Identity.Mappers;

public static class PersistedGrantMappers
{
    static PersistedGrantMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<PersistedGrantMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static PersistedGrantsDto ToModel(this PagedList<PersistedGrantDataView> grant)
    {
        return grant == null ? null : Mapper.Map<PersistedGrantsDto>(grant);
    }

    public static PersistedGrantsDto ToModel(this PagedList<PersistedGrant> grant)
    {
        return grant == null ? null : Mapper.Map<PersistedGrantsDto>(grant);
    }

    public static PersistedGrantDto ToModel(this PersistedGrant grant)
    {
        return grant == null ? null : Mapper.Map<PersistedGrantDto>(grant);
    }
}