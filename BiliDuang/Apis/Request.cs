using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Masuit.Tools;

namespace BiliDuang.Apis
{
    internal static class Request
    {
        private static readonly string userAgent = "";

        public static async Task<JsonNode> CreateRequest(string method, string url, Dictionary<string, object> data)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));
            if (url is null)
                throw new ArgumentNullException(nameof(url));
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            var data2 = data.ToDictionary(t => t.Key, t => t.Value.ToString());
            var headers = new Dictionary<string, string>
            {
                ["User-Agent"] = userAgent,
                ["Cookie"] = BilibiliApi.Cookies.ToHttpString()
            };
            if (method.ToUpperInvariant() == "POST")
                headers["Content-Type"] = "application/x-www-form-urlencoded";
            if (url.Contains("bilibili.com"))
            {
                headers["Referer"] = "https://www.bilibili.com";
                headers["Origin"] = "https://www.bilibili.com";
            }

            try
            {
                using var handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    UseCookies = false,
                    UseProxy = BilibiliApi.UseProxy
                };
                if (BilibiliApi.UseProxy)
                    handler.Proxy = BilibiliApi.Proxy;
                using var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(8);
                if (method.ToUpperInvariant() == "GET")
                {
                    if (data2.Count != 0)
                    {
                        url += "?" + string.Join("&",
                            data2.Select(t => Uri.EscapeDataString(t.Key) + "=" + Uri.EscapeDataString(t.Value)));
                    }

                    data2 = null;
                }

                using var response = await client.SendAsync(url, method, headers, data2);
                response.EnsureSuccessStatusCode();
                if (response.Headers.TryGetValues("Set-Cookie", out var rawSetCookie))
                    BilibiliApi.Cookies.Add(QuickHttp.ParseCookies(rawSetCookie));
                byte[] buffer = await response.Content.ReadAsByteArrayAsync();
                return JsonNode.Parse(Encoding.UTF8.GetString(buffer));
            }
            catch (Exception ex)
            {
                return JsonNode.Parse("{\"code\":502,\"message\":\"内部错误\"}");
            }

            static ulong GetCurrentTotalSeconds()
            {
                var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
                return (ulong)timeSpan.TotalSeconds;
            }

            static ulong GetCurrentTotalMilliseconds()
            {
                var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
                return (ulong)timeSpan.TotalMilliseconds;
            }
        }
    }
}