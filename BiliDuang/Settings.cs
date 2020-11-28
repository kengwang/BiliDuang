using Newtonsoft.Json;
using System;
using System.IO;

namespace BiliDuang
{
    class Settings
    {
        public static string versionCode = "2.1.3";
        public static string versionName = "Mindfuck";

        public static int maxMission = 1;
        public static int useapi = 0; //0 - Bilibili   1 - BiliPlus    2 - BiliBili TV
        public static bool lowcache = false;
        public static bool darkmode = false;
        public static bool autodark = true;
        public static bool usearia2c = false;
        public static string aria2cargument = "";

        public static void SaveSettings()
        {
            _Settings settings = new _Settings();
            settings.maxMission = Settings.maxMission;
            settings.lowcache = Settings.lowcache;
            settings.useapi = Settings.useapi;
            settings.darkmode = Settings.darkmode;
            settings.autodark = Settings.autodark;
            settings.usearia2c = Settings.usearia2c;
            settings.aria2cargument = Settings.aria2cargument;
            File.WriteAllText(Environment.CurrentDirectory + "/config/settings", JsonConvert.SerializeObject(settings));
        }

        public static void ReadSettings()
        {
            try
            {
                _Settings setting = JsonConvert.DeserializeObject<_Settings>(File.ReadAllText(Environment.CurrentDirectory + "/config/settings"));
                Settings.maxMission = setting.maxMission;
                Settings.lowcache = setting.lowcache;
                Settings.useapi = setting.useapi;
                Settings.darkmode = setting.darkmode;
                Settings.autodark = setting.autodark;
                Settings.usearia2c = setting.usearia2c;
                Settings.aria2cargument = setting.aria2cargument;
            }
            catch (Exception e)
            {

            }
        }
    }
    class _Settings
    {
        public int maxMission;
        public bool lowcache = false;
        public int useapi = 0;
        public bool darkmode = false;
        public bool autodark = true;
        public bool usearia2c = false;
        public string aria2cargument = "";
    }
}
