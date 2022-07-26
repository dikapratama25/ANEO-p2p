using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources;
using Abp.Reflection.Extensions;

namespace Plexform.Localization
{
    public static class P2PLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Extensions.Add(
                new LocalizationSourceExtensionInfo(
                    PlexformConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(P2PLocalizationConfigurer).GetAssembly(),
                        "ANEO.Base.P2P.Localization.Plexform"
                    )
                )
            );
        }
    }
}
