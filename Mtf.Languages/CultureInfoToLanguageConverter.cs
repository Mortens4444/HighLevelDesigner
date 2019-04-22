using System.Collections.Generic;
using System.Globalization;

namespace Mtf.Languages
{
    class CultureInfoToLanguageConverter
    {
        private readonly Dictionary<CultureInfo, Language> languages = new Dictionary<CultureInfo, Language>
        {
            { CultureInfo.GetCultureInfo("hu-HU"), Language.Magyar },
            { CultureInfo.GetCultureInfo("de-DE"), Language.Deutch }
        };

        public Language Convert(CultureInfo cultureInfo)
        {
            if (languages.ContainsKey(cultureInfo))
            {
                return languages[cultureInfo];
            }

            return Language.English;
        }
    }
}
