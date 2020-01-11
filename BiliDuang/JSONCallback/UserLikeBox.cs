using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.UserLikeBox
{
    public class Cnt_info
    {
        /// <summary>
        /// 
        /// </summary>
        public int coin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int collect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int danmaku { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int play { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int reply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int share { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int thumb_down { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int thumb_up { get; set; }
    }

    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int attr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Cnt_info cnt_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cover_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fav_state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string intro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int like_state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int media_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 技术
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
    }

    public class UserLikeBox
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
    }
}
