using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.UserTypeCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.AppUserTypeDto
{
    [AutoMap(typeof(UserType))]
    public class UserTypeDto : EntityDto<int>
    { 
        [Required]
        [StringLength(ValidationConst.MaxTopicNameLength)]
        public string UserTypeConst { get; set; }
        [Required]
        [StringLength(ValidationConst.MaxTopicNameLength)]
        public string UserTypeName { get; set; }
    }
}
