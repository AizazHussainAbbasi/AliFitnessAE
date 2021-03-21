using System.Collections.Generic;
using AliFitnessAE.Roles.Dto;

namespace AliFitnessAE.Web.Models.Admin.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}