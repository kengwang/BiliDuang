using System.Collections.Generic;

namespace BiliDuang.JSONCallback.UserBangumiFollow
{
    public class Rights
    {
        /// <summary>
        /// 
        /// </summary>
        public int is_selection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int selection_style { get; set; }
    }

    public class Stat
    {
        /// <summary>
        /// 
        /// </summary>
        public int follow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int view { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int danmaku { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int reply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int coin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int series_follow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int series_view { get; set; }
    }

    public class New_ep
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 更新至第1话
        /// </summary>
        public string index_show { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// LEVEL5超能力者
        /// </summary>
        public string long_title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pub_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
    }

    public class AreasItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 日本
        /// </summary>
        public string name { get; set; }
    }

    public class Series
    {
        /// <summary>
        /// 
        /// </summary>
        public int series_id { get; set; }
        /// <summary>
        /// 某科学的超电磁炮
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int season_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int new_season_id { get; set; }
    }

    public class Publish
    {
        /// <summary>
        /// 
        /// </summary>
        public string pub_time { get; set; }
        /// <summary>
        /// 01月11日00:05
        /// </summary>
        public string pub_time_show { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string release_date { get; set; }
        /// <summary>
        /// 2020年1月11日
        /// </summary>
        public string release_date_show { get; set; }
    }

    public class SectionItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int section_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int season_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int limit_group { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int watch_platform { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string copyright { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ban_area_show { get; set; }
    }

    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int season_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int media_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int season_type { get; set; }
        /// <summary>
        /// 番剧
        /// </summary>
        public string season_type_name { get; set; }
        /// <summary>
        /// 某科学的超电磁炮T
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_finish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_started { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_play { get; set; }
        /// <summary>
        /// 会员抢先
        /// </summary>
        public string badge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int badge_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Rights rights { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Stat stat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public New_ep new_ep { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string square_cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int season_status { get; set; }
        /// <summary>
        /// 第三季
        /// </summary>
        public string season_title { get; set; }
        /// <summary>
        /// 会员
        /// </summary>
        public string badge_ep { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int media_attr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int season_attr { get; set; }
        /// <summary>
        /// 有 230 万人口，其中八成人口为学生的「学园都市」，是比其他地区科技更为先进，并从事「超能力开发」的特殊地区。而整座学园都市中仅有七人的等级 5 超能力者之一御坂美琴，由于她的能力与个性使然，因而被...
        /// </summary>
        public string evaluate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AreasItem> areas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subtitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int first_ep { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int can_watch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Series series { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Publish publish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SectionItem> section { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int follow_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_new { get; set; }
        /// <summary>
        /// 看到第1话 20:26
        /// </summary>
        public string progress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string both_follow { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ps { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
    }

    public class UserBangumiFollow
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
