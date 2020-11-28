using System.Collections.Generic;

namespace BiliDuang.JSONCallback.LikeBoxItem
{
    //如果好用，请收藏地址，帮忙分享。

    public class Cnt_info
    {
        /// <summary>
        /// 
        /// </summary>
        public int collect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int play { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int thumb_up { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int share { get; set; }
    }

    public class Info
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
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
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Upper upper { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cover_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Cnt_info cnt_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string intro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fav_state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int like_state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int media_count { get; set; }
    }

    public class Upper
    {
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 在下蕾姆有何贵干
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }
    }


    public class MediasItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 压抑到极致的瞬间燃爆！！！我拯救了世界 世界却抛弃了我
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// BGM：Tommee Profitt Jung Youth Fleurie - In the End
        /// </summary>
        public string intro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Upper upper { get; set; }
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
        public string link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pubtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fav_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bv_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bvid { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public Info info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MediasItem> medias { get; set; }
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
