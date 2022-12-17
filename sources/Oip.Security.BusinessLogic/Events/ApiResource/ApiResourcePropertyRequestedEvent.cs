﻿using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Dtos.Configuration;

namespace Oip.Security.BusinessLogic.Events.ApiResource
{
    public class ApiResourcePropertyRequestedEvent : AuditEvent
    {
        public ApiResourcePropertyRequestedEvent(int apiResourcePropertyId, ApiResourcePropertiesDto apiResourceProperties)
        {
            ApiResourcePropertyId = apiResourcePropertyId;
            ApiResourceProperties = apiResourceProperties;
        }

        public int ApiResourcePropertyId { get; }
        public ApiResourcePropertiesDto ApiResourceProperties { get; set; }
    }
}