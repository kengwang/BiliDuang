using Newtonsoft.Json;
using System;
using System.IO;

namespace BiliDuang
{
    internal class Settings
    {
        public static string versionCode = "2.1.4";
        public static string versionName = "Tokky";

        public static int maxMission = 1;
        public static int useapi = 0; //0 - Bilibili   1 - BiliPlus    2 - BiliBili TV
        public static bool lowcache = false;
        public static bool darkmode = false;
        public static bool autodark = true;
        public static bool usearia2c = false;
        public static bool downloaddanmaku = false;
        public static string aria2cargument = "";

        public static void SaveSettings()
        {
            _Settings settings = new _Settings
            {
                maxMission = Settings.maxMission,
                lowcache = Settings.lowcache,
                useapi = Settings.useapi,
                darkmode = Settings.darkmode,
                autodark = Settings.autodark,
                usearia2c = Settings.usearia2c,
                aria2cargument = Settings.aria2cargument,
                downloaddanmaku = Settings.downloaddanmaku
            };
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
                Settings.downloaddanmaku = setting.downloaddanmaku;
            }
            catch (Exception)
            {

            }
        }
    }

    internal class _Settings
    {
        public int maxMission;
        public bool lowcache = false;
        public int useapi = 0;
        public bool darkmode = false;
        public bool autodark = true;
        public bool usearia2c = false;
        public bool downloaddanmaku = false;
        public string aria2cargument = "";
    }
}
