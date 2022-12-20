using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Oip.Security.Bl.Dtos.Grant;
using Oip.Security.Dal.Entities;
using Oip.Security.Dal.Extensions.Common;

namespace Oip.Security.Bl.Mappers;

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