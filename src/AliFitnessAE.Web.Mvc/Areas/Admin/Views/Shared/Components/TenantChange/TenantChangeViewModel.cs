using Abp.AutoMapper;
using AliFitnessAE.Sessions.Dto;

namespace AliFitnessAE.Web.Admin.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
