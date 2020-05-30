using Newtonsoft.Json;
using System;
using System.IO;

namespace BiliDuang
{
    class Settings
    {
        public static int maxMission = 1;
        public static bool outland=false;
        public static bool lowcache = false;
        public static void SaveSettings()
        {
            _Settings settings = new _Settings();
            settings.maxMission = Settings.maxMission;
            settings.lowcache = Settings.lowcache;
            settings.outland = Settings.outland;
            File.WriteAllText(Environment.CurrentDirectory+"/config/settings",JsonConvert.SerializeObject(settings));
        }

        public static void ReadSettings()
        {
            try
            {
                _Settings setting = JsonConvert.DeserializeObject<_Settings>(File.ReadAllText(Environment.CurrentDirectory + "/config/settings"));
                Settings.maxMission = setting.maxMission;
                Settings.lowcache = setting.lowcache;
                Settings.outland = setting.outland;
            }catch(Exception e)
            {

            }
        }
    }
    class _Settings
    {
        public int maxMission;
        public bool lowcache = false;
        public bool outland = false;
    }
}
