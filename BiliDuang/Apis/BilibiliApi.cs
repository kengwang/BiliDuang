using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BiliDuang.Apis
{
    public static class BilibiliApi
    {

        /// <summary>
        /// Cookie
        /// </summary>
        public static CookieCollection Cookies;

        /// <summary>
        /// Access Key
        /// </summary>
        public static string AccessKey;


        /// <summary>
        /// 使用代理
        /// </summary>
        public static bool UseProxy;

        /// <summary>
        /// 代理
        /// </summary>
        public static IWebProxy Proxy;

        public static async Task<JsonNode> RequestAsync(BilibiliApiProvider provider,
            Dictionary<string, object> queries = null)
        {
            if (queries is null)
                queries = new Dictionary<string, object>();
            var data = provider.GetData(queries);
            return await RequestAsync(provider.Url, provider.Method, data);
        }
        
        public static async Task<JsonNode> RequestAsync(string url, HttpMethod method,
            Dictionary<string, object> queries = null)
        {
            if (queries is null)
                queries = new Dictionary<string, object>();
            return await Request.CreateRequest(method.Method, url, queries);
        }
    }
    
    
}