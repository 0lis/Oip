using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Oip.Security.BusinessLogic.Dtos.Grant;
using Oip.Security.EntityFramework.Entities;
using Oip.Security.EntityFramework.Extensions.Common;

namespace Oip.Security.BusinessLogic.Mappers;

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