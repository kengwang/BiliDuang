using System.Collections.Generic;

namespace BiliDuang.JSONCallback.Player
{
    public class DurlItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ahead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vhead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> backup_url { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string @from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timelength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accept_format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> accept_description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> accept_quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int video_codecid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string seek_param { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string seek_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DurlItem> durl { get; set; }
    }

    public class Player
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
