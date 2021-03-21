using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AliFitnessAE.Authorization
{
    public class AliFitnessAEAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_UserType, L("UserType"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Topic, L("Topic"));
            context.CreatePermission(PermissionNames.Pages_UserTracking, L("UserTracking"));
            context.CreatePermission(PermissionNames.Pages_PhotoTracking, L("PhotoTracking"));

            var administration = context.CreatePermission(PermissionNames.Pages_Topic_GetTopic, L("GetTopic"));
            var userManagement = administration.CreateChildPermission(PermissionNames.Pages_Topic_CreateTopic, L("CreateTopic"));
            userManagement.CreateChildPermission(PermissionNames.Pages_Topic_UpdateTopic, L("UpdateTopic"));
            userManagement.CreateChildPermission(PermissionNames.Pages_Topic_DeleteTopic, L("DeleteTopic"));
            context.CreatePermission(PermissionNames.Pages_UserTracking_GetAll, L("GetAllUserTracking"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AliFitnessAEConsts.LocalizationSourceName);
        }
    }
}
