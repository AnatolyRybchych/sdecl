using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace sdecl
{
    internal class Cache
    {
        public List<string> HeaderFiles { get; set; }
        public CacheSettings Settings { get; set; }

        public Cache()
        {
            string cacheFolder = FolderPath;
            string cacheSettingsFile = CacheSettingsFilePath;

            
            HeaderFiles = new List<string>();

            if (Directory.Exists(cacheFolder) == false)
                Directory.CreateDirectory(cacheFolder);

            if (File.Exists(cacheSettingsFile) == false)
            {
                Settings = new CacheSettings();
                File.WriteAllText(cacheSettingsFile, JsonSerializer.Serialize(Settings));
            }
            else
            {
                CacheSettings? settings;
                try
                {
                    settings = JsonSerializer.Deserialize<CacheSettings>(File.ReadAllText(cacheSettingsFile));
                }
                catch (Exception)
                {
                    settings = new CacheSettings();
                }

                if (settings == null)
                {
                    settings = new CacheSettings();
                    File.WriteAllText(cacheSettingsFile, JsonSerializer.Serialize(Settings));
                }
                Settings = settings;
            }

            HeaderFiles.AddRange(Directory.GetFiles(cacheFolder).Where(file=>Path.GetExtension(file) == $".{ChacheFileExtension}"));
        }

        public void Serialize() => File.WriteAllText(CacheSettingsFilePath, JsonSerializer.Serialize(Settings));

        public string FolderPath => Path.Combine(AssemblyPath, FolderName);
        public string CacheSettingsFilePath => Path.Combine(AssemblyPath, CacheSettingsFileName);

        public const string CacheSettingsFileName = "CacheSettings.json";
        public const string ChacheFileExtension = "cache.json";
        public const string FolderName = "Cache";

        private string AssemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location ?? "./sdecl.dll") ?? "./";

        public override string ToString()
        {
            return $"cache: {{\n    dirs\n    files\n}}";
        }
    }
}
