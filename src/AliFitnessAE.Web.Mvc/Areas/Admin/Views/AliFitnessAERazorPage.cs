using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AliFitnessAE.Web.Admin.Views
{
    public abstract class AliFitnessAERazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AliFitnessAERazorPage()
        {
            LocalizationSourceName = AliFitnessAEConsts.LocalizationSourceName;
        }
    }
}
