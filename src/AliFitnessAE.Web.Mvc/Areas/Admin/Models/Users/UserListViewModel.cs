using System.Collections.Generic;
using AliFitnessAE.AppUserTypeDto;
using AliFitnessAE.Roles.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AliFitnessAE.Web.Models.Admin.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
        public List<SelectListItem> UserType { get; set; }
        public List<SelectListItem> Gender { get; set; }
    }
}
