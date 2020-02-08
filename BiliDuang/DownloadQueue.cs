using BiliDuang.VideoClass;
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

        public static int AddDownload(DownloadObject obj, bool reald = true)
        {
            if (DownloadingCount <= Settings.maxMission && reald)
            {
                obj.LinkStart();
                DownloadingCount++;
            }
            objs.Add(obj);
            return objs.Count - 1;
        }


        public static void StartAll()
        {
            DownloadingCount = 1;
            bool dontstart = false;
            foreach (DownloadObject obj in objs)
            {
                if (DownloadingCount >= Settings.maxMission && !(obj.status <= 0))
                {
                    obj.Cancel();
                    dontstart = true;
                }

                if (!(obj.status <= 0))
                {
                    DownloadingCount++;
                }
            }
            if (!dontstart)
            {
                foreach (DownloadObject obj in objs)
                {
                    if (DownloadingCount <= Settings.maxMission && !!(obj.status == 9000) && !(obj.status <= 0))
                    {
                        obj.LinkStart();
                        DownloadingCount++;
                    }
                }
            }
        }

        public static void PauseAll()
        {
            foreach (DownloadObject obj in objs)
            {
                obj.Cancel();
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
                DownloadSavedMisson misson = new DownloadSavedMisson();
                misson.aid = dobj.aid;
                misson.cid = dobj.cid;
                misson.name = dobj.name;
                misson.saveto = dobj.saveto;
                misson.quality = dobj.quality;
                ms.Add(misson);
            }
            File.WriteAllText(Environment.CurrentDirectory + "/config/download.session", JsonConvert.SerializeObject(ms));
        }

        public static void readMisson()
        {
            try
            {
                string json = File.ReadAllText(Environment.CurrentDirectory + "/config/download.session");
                List<DownloadSavedMisson> ms = new List<DownloadSavedMisson>();
                ms = JsonConvert.DeserializeObject<List<DownloadSavedMisson>>(json);
                foreach (DownloadSavedMisson dobj in ms)
                {
                    DownloadObject ep = new DownloadObject(dobj.aid, dobj.cid, dobj.quality, dobj.saveto, dobj.name);
                    ep.LinkStart();
                }
            }
            catch (Exception e)
            {
                //防止报错
            }
        }
    }

    class DownloadSavedMisson
    {
        public string aid;
        public string cid;
        public string saveto;
        public int quality;
        public string name;
    }
}
