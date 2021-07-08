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
                        "mail.bodytranscend.com"
                        ),
                  new SettingDefinition(
                        "SmtpPort",
                        "25"
                        ),
                   new SettingDefinition(
                        "SmtpUser",
                        "info@bodytranscend.com"
                        ),
                     new SettingDefinition(
                        "SmtpPass",
                        "786Tran$b0dy@110"
                        ),
                        new SettingDefinition(
                        "From_Info",
                        "info@bodytranscend.com"
                        ),
                           new SettingDefinition(
                        "From_Name",
                        "Body Transcend"
                        ),
            };
        }
    }
}
