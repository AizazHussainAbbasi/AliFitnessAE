using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace AliFitnessAE.AppUserTypeDto
{
    public class UserTypeListDto : AuditedEntity
    { 
        public string UserTypeConst { get; set; } 
        public string UserTypeName { get; set; }
    }
}
