using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BiliDuang
{
    class Video
    {
        public int Type;
        public List<VideoClass.AV> av=new List<VideoClass.AV>();
        public VideoClass.SS ss;

        public Video(string vlink)
        {
            //第一步,bilibili网址转换
            //注意垃圾spm!
            //例如 https://www.bilibili.com/bangumi/play/ss28615?spm=3.0212
            if (vlink.EndsWith("/"))
            {
                vlink.Substring(0, vlink.Length - 1);
            }
            vlink = Other.TextGetCenter("/","?",vlink);
            

            //第二步判断格式

            if (vlink.Contains("av"))
            {
                Type = VideoType.AV;
                ProcessAV(vlink.Replace("av",""));
            }else if (vlink.Contains("ep"))
            {
                ProcessEP(vlink.Replace("ep", ""));
            }
            else if (vlink.Contains("ss"))
            {
                Type = VideoType.SS;
                ProcessSS(vlink.Replace("ss", ""));
            }
            else if(vlink.Contains("md"))
            {
                ProcessMD(vlink.Replace("md", ""));
            }
            else
            {
                Dialog.Show("不是可以获取的格式,请检查格式是否正确");
            }
        }

        private bool ProcessAV(string avid)
        {
            VideoClass.AV nav = new VideoClass.AV(avid);
            av.Add(nav);
            return true;
        }

        private bool ProcessSS(string vlink)
        {
            VideoClass.SS nss = new VideoClass.SS(vlink);
            ss = nss;
            return true;
        }

        private bool ProcessEP(string vlink)
        {
            return false;
        }

        private bool ProcessMD(string vlink)
        {
            return false;
        }

        

    }
}
