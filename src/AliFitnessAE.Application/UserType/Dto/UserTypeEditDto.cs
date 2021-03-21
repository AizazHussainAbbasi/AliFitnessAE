using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.UserTypeCore;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.AppUserTypeDto
{
    [AutoMap(typeof(UserType))]
    public class UserTypeEditDto: EntityDto<int>
    { 

        [Required]
        [StringLength(ValidationConst.MaxTopicNameLength)]
        public string UserTypeConst { get; set; }
        [Required]
        [StringLength(ValidationConst.MaxTopicNameLength)]
        public string UserTypeName { get; set; }
    }
}