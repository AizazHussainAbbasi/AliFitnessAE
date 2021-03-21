using Abp.AutoMapper;
using AliFitnessAE.Roles.Dto;
using AliFitnessAE.Web.Models.Admin.Common;

namespace AliFitnessAE.Web.Models.Admin.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
