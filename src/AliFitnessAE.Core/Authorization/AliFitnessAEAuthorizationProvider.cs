using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AliFitnessAE.Authorization
{
    public class AliFitnessAEAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_UserType, L("UserType"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Topic, L("Topic"));
            context.CreatePermission(PermissionNames.Pages_UserTracking, L("UserTracking"));
            context.CreatePermission(PermissionNames.Pages_PhotoTracking, L("PhotoTracking"));

            var user = context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            var userManagement = user.CreateChildPermission(PermissionNames.Pages_User_CreateUsers, L("CreateUsers"));
            userManagement.CreateChildPermission(PermissionNames.Pages_User_UpdateUsers, L("UpdateUsers"));
            userManagement.CreateChildPermission(PermissionNames.Pages_User_DeleteUsers, L("DeleteUsers"));

            var topic = context.CreatePermission(PermissionNames.Pages_Topic_GetTopic, L("GetTopic"));
            var topicManagement = topic.CreateChildPermission(PermissionNames.Pages_Topic_CreateTopic, L("CreateTopic"));
            topicManagement.CreateChildPermission(PermissionNames.Pages_Topic_UpdateTopic, L("UpdateTopic"));
            topicManagement.CreateChildPermission(PermissionNames.Pages_Topic_DeleteTopic, L("DeleteTopic"));
            context.CreatePermission(PermissionNames.Pages_UserTracking_GetAll, L("GetAllUserTracking"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AliFitnessAEConsts.LocalizationSourceName);
        }
    }
}
