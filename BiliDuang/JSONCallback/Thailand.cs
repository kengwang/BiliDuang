using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.Thailand
{


    public class Stream_info
    {
        /// <summary>
        /// 
        /// </summary>
        public int quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string new_description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string display_desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string need_vip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string need_login { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string intact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string no_rexcode { get; set; }
    }

    public class Dash_video
    {
        /// <summary>
        /// 
        /// </summary>
        public string base_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bandwidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int codecid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string md5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int audio_id { get; set; }
    }

    public class Stream_listItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Stream_info stream_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dash_video dash_video { get; set; }
    }

    public class Dash_audioItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string base_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string backup_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bandwidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int codecid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string md5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
    }

    public class Video_info
    {
        /// <summary>
        /// 
        /// </summary>
        public int quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timelength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Stream_listItem> stream_list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Dash_audioItem> dash_audio { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public Video_info video_info { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ttl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
}
