using System;

namespace Mtf.Languages
{
    internal class JsonConvert
    {
        internal static LanguageElements CreateLanguageElements(string languageFileContent)
        {
            var result = new LanguageElements();

            var rawKeysAndValues = languageFileContent.Split(new[] { ":", $",{Environment.NewLine}" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rawKeysAndValues.Length; i += 2)
            {
                var key = NormalizeValue(rawKeysAndValues[i]);
                var value = NormalizeValue(rawKeysAndValues[i + 1]);

                result[key] = value;
            }

            return result;
        }

        private static string NormalizeValue(string value)
        {
            var first = value.IndexOf('"') + 1;
            var last = value.LastIndexOf('"');
            return value.Substring(first, last - first);
        }
    }
}
