using System.Collections.Generic;
using Abp.Configuration;

namespace AliFitnessAE.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
                 new SettingDefinition(
                        "SmtpHost",
                        "smtp.ethereal.email"
                        ),
                  new SettingDefinition(
                        "SmtpPort",
                        "587"
                        ),
                   new SettingDefinition(
                        "SmtpUser",
                        "nyah.hilll57@ethereal.email"
                        ),
                     new SettingDefinition(
                        "SmtpPass",
                        "mQ68k19u2H5X3VfeU3"
                        ),
            };
        }
    }
}
