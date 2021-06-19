using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.Users.Dto
{ 
    public class ChangePersonalDetailDto  
    {
        public long Id { get; set; }
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; } 
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; } 
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(ValidationConst.MaxPhoneNumberLength)]
        [RegularExpression(@"^(?:\+971|00971|0)?(?:50|51|52|55|56|2|3|4|6|7|9)\d{7}$", ErrorMessage = "Not a valid phone number")]
        public string MobileNumber { get; set; }
        public string LandLineNumber { get; set; }
        public string ZoomId { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public char Gender { get; set; }
    }
}
