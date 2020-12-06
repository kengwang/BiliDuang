using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BiliDuang.VideoClass
{
    internal class SS
    {
        public JSONCallback.Season.Season ep;
        public bool status;
        public List<SeasonSection> ss = new List<SeasonSection>();

        public SS(string sid)
        {
            //https://api.bilibili.com/pgc/web/season/section?season_id=28615
            WebClient MyWebClient = new WebClient
            {
                Credentials = CredentialCache.DefaultCredentials//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            };
            string callback = Encoding.UTF8.GetString(MyWebClient.DownloadData("https://api.bilibili.com/pgc/web/season/section?season_id=" + sid)); 
            ep = JsonConvert.DeserializeObject<JSONCallback.Season.Season>(callback);
            MyWebClient.Dispose();
            if (ep.code != 0)
            {
                Dialog.Show(ep.message, "获取错误");
                status = false;
                return;
            }

            status = true;

            //MainSection
            ss.Add(new SeasonSection(ep.result.main_section.title, ep.result.main_section.episodes));
            foreach (JSONCallback.Season.SectionItem section in ep.result.section)
            {
                ss.Add(new SeasonSection(section.title, section.episodes));
            }

        }
    }

    public class SeasonSection
    {
        public string name;
        public List<episode> episodes = new List<episode>();
        private readonly string _pic;

        public SeasonSection(string name, List<JSONCallback.Season.EpisodesItem> eps)
        {
            this.name = name;
            foreach (JSONCallback.Season.EpisodesItem ep in eps)
            {
                episode episode = new episode
                {
                    aid = ep.aid,
                    cid = ep.cid,
                    pic = ep.cover,
                    name = ep.title + " - " + ep.long_title
                };
                episodes.Add(episode);
            }
        }
    }
}
