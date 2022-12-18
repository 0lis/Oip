using AutoMapper;
using Oip.Security.BusinessLogic.Dtos.Log;
using Oip.Security.EntityFramework.Entities;
using Oip.Security.EntityFramework.Extensions.Common;
using Skoruba.AuditLogging.EntityFramework.Entities;

namespace Oip.Security.BusinessLogic.Mappers;

public class LogMapperProfile : Profile
{
    public LogMapperProfile()
    {
        CreateMap<Log, LogDto>(MemberList.Destination)
            .ReverseMap();

        CreateMap<PagedList<Log>, LogsDto>(MemberList.Destination)
            .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));

        CreateMap<AuditLog, AuditLogDto>(MemberList.Destination)
            .ReverseMap();

        CreateMap<PagedList<AuditLog>, AuditLogsDto>(MemberList.Destination)
            .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));
    }
}