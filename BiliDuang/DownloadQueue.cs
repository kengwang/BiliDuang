using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
