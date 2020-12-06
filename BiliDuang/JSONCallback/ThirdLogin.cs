using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.ThirdLogin
{
    public class User_info
    {
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string api_host { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int has_login { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int direct_login { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public User_info user_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string confirm_uri { get; set; }
    }

    public class ThirdLogin
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
}
