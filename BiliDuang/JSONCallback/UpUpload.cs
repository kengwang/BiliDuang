using System.Collections.Generic;

namespace BiliDuang.JSONCallback.UpUpload
{
    public class VlistItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int typeid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int play { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subtitle { get; set; }
        /// <summary>
        /// 你吃到的鱿鱼从哪儿来？不用网具，如何巧妙地诱捕鱿鱼？
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string copyright { get; set; }
        /// <summary>
        /// 【回形针PaperClip】如何吃上肥美的大鱿鱼？
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int review { get; set; }
        /// <summary>
        /// 回形针PaperClip
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int video_review { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bvid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hide_click { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_pay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_union_video { get; set; }
    }

    public class List
    {
        /// <summary>
        /// 
        /// </summary>
        public List<VlistItem> vlist { get; set; }
    }

    public class Page
    {
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ps { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Page page { get; set; }
    }

    public class UpUpload
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
