using Newtonsoft.Json;
using System.IO;

namespace WorkTimeTracker
{
    public class SettingsData
    {
        private static SettingsData _instance;
        private static string settingsFilePath = "settings.json"; // Pfad der JSON-Datei

        // Privater Konstruktor, um die Instanz zu verhindern
        private SettingsData() { }

        public static SettingsData GetInstance()
        {
            if (_instance == null)
            {
                _instance = LoadSettings(); // Lädt die Einstellungen beim ersten Aufruf
            }
            return _instance;
        }

        public bool ShowTimestampsWithoutSeconds { get; set; }
        public bool ShowTimestamps12hFormat { get; set; }
        public bool ShowExportExcelFeature { get; set; }
        public bool ShowExportPdfFeature { get; set; }
        public bool ShowFormAlwaysOnTop { get; set; }
        public bool ShowFormMinimalistic { get; set; }

        public int FormTransparency { get; set; } = 100;


        public static SettingsData LoadSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                string json = File.ReadAllText(settingsFilePath);
                return JsonConvert.DeserializeObject<SettingsData>(json); // Deserialisiert JSON in SettingsData
            }
            return new SettingsData(); // Rückgabe einer neuen Instanz, falls keine Datei existiert
        }

        public void SaveSettings()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }
    }
}
