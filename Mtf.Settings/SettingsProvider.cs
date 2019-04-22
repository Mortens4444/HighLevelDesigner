using Newtonsoft.Json;
using System.IO;

namespace Mtf.Settings
{
    public static class SettingsProvider
    {
        private static readonly string SettingsFileName = "settings.json";

        public static void SaveSettings(Settings settings)
        {
            var creator = new FileCreator();
            creator.CreateNewFile(SettingsFileName, settings.ToString());
        }

        /// <summary>
        /// Get setting from the settings file.
        /// </summary>
        /// <returns>Current settings in the file.</returns>
        public static Settings Get()
        {
            var reader = new Reader();

            if (!File.Exists(SettingsFileName))
            {
                var result = new Settings();
                SaveSettings(result);
                return result;
            }

            var fileContent = reader.GetFileContent(SettingsFileName);
            return JsonConvert.DeserializeObject<Settings>(fileContent);
        }
    }
}
