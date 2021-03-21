using Abp.Authorization;
using AliFitnessAE.Authorization.Roles;
using AliFitnessAE.Authorization.Users;

namespace AliFitnessAE.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
