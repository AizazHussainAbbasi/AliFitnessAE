using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AliFitnessAE.Controllers
{
    public abstract class AliFitnessAEControllerBase: AbpController
    {
        protected AliFitnessAEControllerBase()
        {
            LocalizationSourceName = AliFitnessAEConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
