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

        public static int AddDownload(DownloadObject obj)
        {

            if (DownloadingCount <= Settings.maxMission)
            {
                obj.Start();
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
                if (DownloadingCount >= Settings.maxMission && !obj.pause)
                {
                    obj.Pause();
                    dontstart = true;
                }

                if (!obj.pause)
                {
                    DownloadingCount++;
                }
            }
            if (!dontstart)
            {
                foreach (DownloadObject obj in objs)
                {
                    if (DownloadingCount <= Settings.maxMission && !obj.complete && obj.pause)
                    {
                        obj.Start();
                        DownloadingCount++;
                    }
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
                misson.aid = dobj.parent.aid;
                misson.cid = dobj.parent.cid;
                misson.name = dobj.parent.name;
                misson.saveto = dobj.parent.savedir;
                misson.quality = dobj.parent.selectedquality;
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
                ms=JsonConvert.DeserializeObject<List<DownloadSavedMisson>>(json);
                foreach (DownloadSavedMisson dobj in ms)
                {
                    episode ep = new episode();
                    ep.aid = dobj.aid;
                    ep.cid = dobj.cid;
                    ep.savedir = dobj.saveto;
                    ep.name = dobj.name;
                    ep.selectedquality = dobj.quality;
                    ep.Download();
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
