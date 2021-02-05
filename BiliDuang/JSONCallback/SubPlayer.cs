using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.SubPlayer
{

    public class SubtitlesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lan { get; set; }
        /// <summary>
        /// 中文（中国）
        /// </summary>
        public string lan_doc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_lock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int author_mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subtitle_url { get; set; }
    }

    public class Subtitle
    {
        /// <summary>
        /// 
        /// </summary>
        public string allow_submit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lan_doc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SubtitlesItem> subtitles { get; set; }
    }

    public class Data
    {

        public Subtitle subtitle { get; set; }
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
