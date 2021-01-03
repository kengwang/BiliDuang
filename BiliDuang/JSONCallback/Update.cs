using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.Update
{
    public class Author
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string login { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatar_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string html_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string followers_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string following_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gists_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string starred_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subscriptions_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string organizations_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string repos_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string events_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string received_events_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
    }

    public class AssetsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string browser_download_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tag_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string target_commitish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string prerelease { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Author author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string created_at { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AssetsItem> assets { get; set; }
    }
}
