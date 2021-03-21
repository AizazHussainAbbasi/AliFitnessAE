using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AliFitnessAE.Localization
{
    public static class AliFitnessAELocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AliFitnessAEConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AliFitnessAELocalizationConfigurer).GetAssembly(),
                        "AliFitnessAE.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
