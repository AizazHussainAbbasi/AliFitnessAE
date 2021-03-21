using System.Collections.Generic;
using AliFitnessAE.Roles.Dto;

namespace AliFitnessAE.Web.Models.Admin.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
