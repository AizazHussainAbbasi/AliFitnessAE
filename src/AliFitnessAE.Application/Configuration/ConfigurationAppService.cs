using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AliFitnessAE.Configuration.Dto;

namespace AliFitnessAE.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AliFitnessAEAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
