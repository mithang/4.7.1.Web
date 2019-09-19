using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MediHub.Touchee.Localization
{
    public static class ToucheeLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ToucheeConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ToucheeLocalizationConfigurer).GetAssembly(),
                        "MediHub.Touchee.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
