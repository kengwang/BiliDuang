using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.BiliPlus
{
    public class DurlItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
    }

    public class LoginStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public string isLogin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vip_expire { get; set; }
    }

    public class Player
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> accept_description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accept_format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> accept_quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DurlItem> durl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string has_paid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }
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
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timelength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int video_codecid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string video_project { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vip_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vip_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flvjsType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public LoginStatus loginStatus { get; set; }
    }
}
