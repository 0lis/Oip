﻿using AutoMapper;
using Oip.Security.BusinessLogic.Dtos.Log;
using Oip.Security.EntityFramework.Entities;
using Oip.Security.EntityFramework.Extensions.Common;
using Skoruba.AuditLogging.EntityFramework.Entities;

namespace Oip.Security.BusinessLogic.Mappers;

public static class LogMappers
{
    static LogMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<LogMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static LogDto ToModel(this Log log)
    {
        return Mapper.Map<LogDto>(log);
    }

    public static LogsDto ToModel(this PagedList<Log> logs)
    {
        return Mapper.Map<LogsDto>(logs);
    }

    public static AuditLogsDto ToModel<TAuditLog>(this PagedList<TAuditLog> auditLogs)
        where TAuditLog : AuditLog
    {
        return Mapper.Map<AuditLogsDto>(auditLogs);
    }

    public static AuditLogDto ToModel(this AuditLog auditLog)
    {
        return Mapper.Map<AuditLogDto>(auditLog);
    }

    public static Log ToEntity(this LogDto log)
    {
        return Mapper.Map<Log>(log);
    }
}