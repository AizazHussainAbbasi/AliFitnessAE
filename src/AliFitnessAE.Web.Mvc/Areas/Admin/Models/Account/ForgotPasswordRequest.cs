using Abp.Authorization.Users;
using System.ComponentModel.DataAnnotations;

namespace AliFitnessAE.Web.Models.Admin.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        //[EmailAddress]
        //[StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string Email { get; set; }
    }
}
