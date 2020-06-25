using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.UserLikeBox
{
    //如果好用，请收藏地址，帮忙分享。
    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int attr { get; set; }
        /// <summary>
        /// 默认收藏夹
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fav_state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int media_count { get; set; }
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
