using Abp.AutoMapper;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.UserTypeCore;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.AppUserTypeDto
{

    [AutoMapTo(typeof(UserType))] 
    public class CreateUserTypeDto
    { 
        [Required]
        [StringLength(ValidationConst.MaxTopicNameLength)]
        public string UserTypeConst { get; set; }
        [Required]
        [StringLength(ValidationConst.MaxTopicNameLength)]
        public string UserTypeName { get; set; } 
    }
}
