using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.Cheese
{


    //如果好用，请收藏地址，帮忙分享。
    public class ImgItem
    {
        /// <summary>
        /// 
        /// </summary>
        public double aspect_ratio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
    }

    public class Brief
    {
        /// <summary>
        /// 
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ImgItem> img { get; set; }
        /// <summary>
        /// 课程概述
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }

    public class Cooperation
    {
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
    }

    public class Coupon
    {
        /// <summary>
        /// 
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int coupon_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expire_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string show_amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string start_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 【上新限时6折】仅限《白宫里的主角们》领用
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token { get; set; }
    }

    public class Episode_page
    {
        /// <summary>
        /// 
        /// </summary>
        public string next { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
    }

    public class Episode_tag
    {
        /// <summary>
        /// 部分试看
        /// </summary>
        public string part_preview_tag { get; set; }
        /// <summary>
        /// 付费
        /// </summary>
        public string pay_tag { get; set; }
        /// <summary>
        /// 全集试看
        /// </summary>
        public string preview_tag { get; set; }
    }

    public class EpisodesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
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
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int play { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int release_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 【先导片】白宫里的主角们
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string watched { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int watchedHistory { get; set; }
    }

    public class Faq
    {
        /// <summary>
        /// Q：课程在什么时间更新？
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 常见问题
        /// </summary>
        public string title { get; set; }
    }

    public class ItemsItem
    {
        /// <summary>
        /// 课程更新频次以页面前端展示为准。购买成功后，课程更新将通过账号动态提示，方便及时观看。
        /// </summary>
        public string answer { get; set; }
        /// <summary>
        /// 课程在什么时间更新？
        /// </summary>
        public string question { get; set; }
    }

    public class Faq1
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ItemsItem> items { get; set; }
        /// <summary>
        /// 常见问题
        /// </summary>
        public string title { get; set; }
    }

    public class Payment
    {
        /// <summary>
        /// 
        /// </summary>
        public int bp_enough { get; set; }
        /// <summary>
        /// 券后 108 B币起/20期
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 108 B币
        /// </summary>
        public string discount_desc { get; set; }
        /// <summary>
        /// 券后
        /// </summary>
        public string discount_prefix { get; set; }
        /// <summary>
        /// 券后支付 108 B币即可观看所有视频
        /// </summary>
        public string pay_shade { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string price_format { get; set; }
        /// <summary>
        /// 立即购买
        /// </summary>
        public string refresh_text { get; set; }
        /// <summary>
        /// 领券购买
        /// </summary>
        public string select_text { get; set; }
    }

    public class Previewed_purchase_note
    {
        /// <summary>
        /// 试看5分钟，购买后即可观看完整内容
        /// </summary>
        public string long_watch_text { get; set; }
        /// <summary>
        /// 券后支付
        /// </summary>
        public string pay_text { get; set; }
        /// <summary>
        ///  108 B币
        /// </summary>
        public string price_format { get; set; }
        /// <summary>
        /// 即可观看所有视频
        /// </summary>
        public string watch_text { get; set; }
        /// <summary>
        /// 试看中，购买即可观看完整内容
        /// </summary>
        public string watching_text { get; set; }
    }

    public class Content_listItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string bold { get; set; }
        /// <summary>
        /// 本内容为付费内容，购买成功后方可观看。
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string number { get; set; }
    }

    public class Purchase_format_note
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Content_listItem> content_list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 购买须知
        /// </summary>
        public string title { get; set; }
    }

    public class Purchase_note
    {
        /// <summary>
        /// 1. 本内容为付费内容，购买成功后方可观看。
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 购买须知
        /// </summary>
        public string title { get; set; }
    }

    public class Purchase_protocol
    {
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 哔哩哔哩付费内容购买协议
        /// </summary>
        public string title { get; set; }
    }

    public class Recommend_seasonsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 共13期
        /// </summary>
        public string ep_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string season_url { get; set; }
        /// <summary>
        /// 看懂美国内政外交的行为逻辑
        /// </summary>
        public string subtitle { get; set; }
        /// <summary>
        /// 王骁Albert：美国背面研究报告
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int view { get; set; }
    }

    public class Stat
    {
        /// <summary>
        /// 
        /// </summary>
        public int play { get; set; }
        /// <summary>
        /// 871.2万播放
        /// </summary>
        public string play_desc { get; set; }
    }

    public class Pendant
    {
        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pid { get; set; }
    }

    public class Up_info
    {
        /// <summary>
        /// 
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 沈逸老师：复旦大学国际政治系教授
        /// </summary>
        public string brief { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int follower { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_follow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Pendant pendant { get; set; }
        /// <summary>
        /// 观察者网
        /// </summary>
        public string uname { get; set; }
    }

    public class User_status
    {
        /// <summary>
        /// 
        /// </summary>
        public int favored { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int favored_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int payed { get; set; }
    }

    public class Data
    {
        public string course_content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> courses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Episode_page episode_page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int episode_sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Episode_tag episode_tag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<EpisodesItem> episodes { get; set; }
        /// <summary>
        /// 火速更新中~
        /// </summary>
        public string release_bottom_info { get; set; }
        /// <summary>
        /// 更新中，更新至第14期 | 共20期
        /// </summary>
        public string release_info { get; set; }
        /// <summary>
        /// 更新至第14期 | 共20期
        /// </summary>
        public string release_info2 { get; set; }
        /// <summary>
        /// 更新中
        /// </summary>
        public string release_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int season_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string share_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string short_link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 细说美国的“黄金40年”与霸权陨落
        /// </summary>
        public string subtitle { get; set; }
        /// <summary>
        /// 沈逸：白宫里的主角们
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Up_info up_info { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
    }


}
