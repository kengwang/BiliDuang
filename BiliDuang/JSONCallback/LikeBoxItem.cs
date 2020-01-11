using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.LikeBoxItem
{
    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string bv_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bvid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fav_state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fav_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int like_state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string short_link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }

    public class LikeBoxItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
    }
}
