using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.Season
{
    public class EpisodesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string badge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int badge_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string long_title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string share_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vid { get; set; }
    }

    public class Main_section
    {
        /// <summary>
        /// 
        /// </summary>
        public List<EpisodesItem> episodes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 正片
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }


    public class SectionItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<EpisodesItem> episodes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        public Main_section main_section { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SectionItem> section { get; set; }
    }

    public class Season
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
        public Result result { get; set; }
    }
}
