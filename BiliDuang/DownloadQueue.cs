using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BiliDuang
{
    public class DownloadQueue
    {
        public static List<DownloadObject> objs = new List<DownloadObject>();
        public static int DownloadingCount = 1;
        private static readonly long _totalspeed = 0;
        public static long totalspeed =>
                /*
_totalspeed = 0;
foreach (DownloadObject a in objs)
{
_totalspeed = _totalspeed + a.speed;
}*/
                0;

        public static int AddDownload(DownloadObject obj, bool reald = true)
        {
            objs.Add(obj);
            if (DownloadingCount <= Settings.maxMission && reald)
            {
                obj.LinkStart();
                DownloadingCount++;
            }
            return objs.Count - 1;
        }


        public static void StartAll()
        {
            DownloadingCount = 1;
            foreach (DownloadObject obj in objs)
            {
                if (DownloadingCount <= Settings.maxMission)
                {
                    if (obj.status != 5)
                        obj.LinkStart();
                    DownloadingCount++;
                }
                else
                {
                    obj.Pause();
                }
            }
        }

        public static void PauseAll()
        {
            foreach (DownloadObject obj in objs)
            {
                obj.Pause();
            }
        }

        internal static void MoveNext(int index)
        {
            if (objs.Count - 2 >= index)
            {
                if (objs[index + 1].status != 0) return;
                objs[index + 1].LinkStart();
            }
        }

        public static void DeleteAll()
        {
            foreach (DownloadObject obj in objs)
            {
                obj.Cancel();
            }
            objs.Clear();
        }

        public static void SaveMissons()
        {
            if (objs.Count == 0)
            {
                File.Delete(Environment.CurrentDirectory + "/config/download.session");
                return;
            }
            List<DownloadSavedMisson> ms = new List<DownloadSavedMisson>();
            foreach (DownloadObject dobj in DownloadQueue.objs)
            {
                DownloadSavedMisson misson = new DownloadSavedMisson
                {
                    aid = dobj.aid,
                    cid = dobj.cid,
                    name = dobj.name,
                    saveto = dobj.saveto,
                    quality = dobj.quality,
                    avname = dobj.avname
                };
                ms.Add(misson);
            }
            File.WriteAllText(Environment.CurrentDirectory + "/config/download.session", JsonConvert.SerializeObject(ms));
        }

        public static void readMisson()
        {
            try
            {
                Settings.ReadSettings();
                string json = File.ReadAllText(Environment.CurrentDirectory + "/config/download.session");
                List<DownloadSavedMisson> ms = new List<DownloadSavedMisson>();
                ms = JsonConvert.DeserializeObject<List<DownloadSavedMisson>>(json);
                foreach (DownloadSavedMisson dobj in ms)
                {
                    DownloadObject obj = new DownloadObject(dobj.aid, dobj.cid, dobj.quality, dobj.saveto, dobj.name, dobj.avname);
                    DownloadQueue.AddDownload(obj);
                }
            }
            catch (Exception)
            {
                //防止报错
            }
        }
    }

    internal class DownloadSavedMisson
    {
        public string aid;
        public string avname;
        public string cid;
        public string saveto;
        public int quality;
        public string name;
    }
}