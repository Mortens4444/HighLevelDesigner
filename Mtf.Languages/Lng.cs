using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Mtf.Languages
{
    public static class Lng
    {
        private static Language Language;

        /// <summary>
        /// Memory usage can be reduced if only the current languge elements are loaded, not all languages.
        /// </summary>
        private static readonly Dictionary<(Language Language, string ElementIdentifier), string> AllLanguageElements = new Dictionary<(Language Language, string ElementIdentifier), string>();

        static Lng()
        {
            ChangeToLanguage(CultureInfo.CurrentCulture);

            var embeddedResourceReader = new EmbeddedResourceReader();
            var languages = Enum.GetValues(typeof(Language));
            foreach (var language in languages)
            {
                var languageFileContent = embeddedResourceReader.GetContent(Assembly.GetCallingAssembly(), $"Mtf.Languages.Languages.{language}.json");
                var languageElements = JsonConvert.CreateLanguageElements(languageFileContent);

                foreach (var languageElement in languageElements)
                {
                    var key = ((Language)language, languageElement.Key);
                    AllLanguageElements.Add(key, languageElement.Value);
                }
            }
        }

        public static void ChangeToLanguage(CultureInfo cultureInfo)
        {
            var cultureInfoToLanguageConverter = new CultureInfoToLanguageConverter();
            ChangeToLanguage(cultureInfoToLanguageConverter.Convert(cultureInfo));
        }

        public static void ChangeToLanguage(Language language)
        {
            Language = language;
        }

        public static void LoadLanguageElements(params (dynamic TextContainer, string LanguageElementIdentifier)[] languageElementFillers)
        {
            foreach (var item in languageElementFillers)
            {
                item.TextContainer.Text = Elem(item.LanguageElementIdentifier);
            }
        }

        public static string Elem(string elementIdentifier)
        {
            var result = GetLanguageElement(elementIdentifier, Language);
            if (String.IsNullOrEmpty(result))
            {
                result = GetLanguageElement(elementIdentifier);
            }
            return String.IsNullOrEmpty(result) ? elementIdentifier : result;
        }

        private static string GetLanguageElement(string elementIdentifier, Language language = Language.English)
        {
            var key = (language, elementIdentifier);
            return AllLanguageElements.ContainsKey(key) ? AllLanguageElements[key] : null;
        }
    }
}
