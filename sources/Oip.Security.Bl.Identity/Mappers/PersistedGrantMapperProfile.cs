using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Oip.Security.Bl.Identity.Dtos.Grant;
using Oip.Security.Dal.Entities;
using Oip.Security.Dal.Extensions.Common;

namespace Oip.Security.Bl.Identity.Mappers;

public class PersistedGrantMapperProfile : Profile
{
    public PersistedGrantMapperProfile()
    {
        // entity to model
        CreateMap<PersistedGrant, PersistedGrantDto>(MemberList.Destination)
            .ReverseMap();

        CreateMap<PersistedGrantDataView, PersistedGrantDto>(MemberList.Destination);

        CreateMap<PagedList<PersistedGrantDataView>, PersistedGrantsDto>(MemberList.Destination)
            .ForMember(x => x.PersistedGrants,
                opt => opt.MapFrom(src => src.Data));

        CreateMap<PagedList<PersistedGrant>, PersistedGrantsDto>(MemberList.Destination)
            .ForMember(x => x.PersistedGrants,
                opt => opt.MapFrom(src => src.Data));
    }
}