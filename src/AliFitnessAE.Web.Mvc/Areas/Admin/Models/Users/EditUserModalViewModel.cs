using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.Roles.Dto;
using AliFitnessAE.Users.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AliFitnessAE.Web.Models.Admin.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }
        public List<SelectListItem> UserType { get; set; }
        public List<SelectListItem> Gender { get; set; }
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
