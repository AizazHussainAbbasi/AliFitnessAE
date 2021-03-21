using Abp.AspNetCore.Mvc.ViewComponents;

namespace AliFitnessAE.Web.Views
{
    public abstract class AliFitnessAEViewComponent : AbpViewComponent
    {
        protected AliFitnessAEViewComponent()
        {
            LocalizationSourceName = AliFitnessAEConsts.LocalizationSourceName;
        }
    }
}
