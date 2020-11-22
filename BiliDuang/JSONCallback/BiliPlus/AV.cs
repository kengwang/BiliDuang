using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.BiliPlus
{
    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string part { get; set; }
    }

    public class Attribute_info
    {
        /// <summary>
        /// 
        /// </summary>
        public string HasHD5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsPGC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsBangumi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LimitArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string JumpURL { get; set; }
    }

    public class Ads_control
    {
        /// <summary>
        /// 
        /// </summary>
        public int has_danmu { get; set; }
    }

    public class Cm_config
    {
        /// <summary>
        /// 
        /// </summary>
        public Ads_control ads_control { get; set; }
    }

    public class Config
    {
        /// <summary>
        /// 相关推荐
        /// </summary>
        public string relates_title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int autoplay_countdown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int share_style { get; set; }
    }

    public class Dimension
    {
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rotate { get; set; }
    }

    public class Owner
    {
        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 哔哩哔哩番剧出差
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }
    }

    public class Official_verify
    {
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 哔哩哔哩番剧出差 官方账号
        /// </summary>
        public string desc { get; set; }
    }

    public class Label
    {
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }
    }

    public class Vip
    {
        /// <summary>
        /// 
        /// </summary>
        public int vipType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long vipDueDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dueRemark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int accessStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vipStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vipStatusWarn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int themeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Label label { get; set; }
    }

    public class Owner_ext
    {
        /// <summary>
        /// 
        /// </summary>
        public Official_verify official_verify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Vip vip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string assists { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fans { get; set; }
    }

    public class PagesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string part { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string weblink { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dimension dimension { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dmlink { get; set; }
        /// <summary>
        /// 视频已缓存完成
        /// </summary>
        public string download_title { get; set; }
        /// <summary>
        /// 【1月】DARLING in the FRANXX（僅限港澳台地區） 01 Darifura_ep01_x264.mp4
        /// </summary>
        public string download_subtitle { get; set; }
    }

    public class Rights
    {
        /// <summary>
        /// 
        /// </summary>
        public int bp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int elec { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int download { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int movie { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int hd5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int no_reprint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int autoplay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ugc_pay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_cooperation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ugc_pay_preview { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int no_background { get; set; }
    }

    public class User_season
    {
        /// <summary>
        /// 
        /// </summary>
        public string attention { get; set; }
    }

    public class Season
    {
        /// <summary>
        /// 
        /// </summary>
        public string season_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_jump { get; set; }
        /// <summary>
        /// DARLING in the FRANXX（僅限港澳台地區）
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_finish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newest_ep_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newest_ep_index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string weekday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public User_season user_season { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ogv_play_url { get; set; }
    }

    public class Stat
    {
        /// <summary>
        /// 
        /// </summary>
        public int aid { get; set; }
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
        public int favorite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int coin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int share { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int now_rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int his_rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int like { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dislike { get; set; }
    }

    public class Act
    {
        /// <summary>
        /// 
        /// </summary>
        public string icon { get; set; }
    }

    public class @new
    {
        /// <summary>
        /// 
        /// </summary>
        public string icon { get; set; }
    }

    public class T_icon
    {
        /// <summary>
        /// 
        /// </summary>
        public Act act { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public @new @new { get; set; }
    }

    public class TagItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int tag_id { get; set; }
        /// <summary>
        /// BILIBILI正版
        /// </summary>
        public string tag_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int likes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int hates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int liked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int hated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int attribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_activity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uri { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tag_type { get; set; }
    }

    public class V2_app_api
    {
        /// <summary>
        /// 
        /// </summary>
        public string aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int attribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Attribute_info attribute_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bvid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Cm_config cm_config { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Config config { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int copyright { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dimension dimension { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dm_seg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @dynamic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Owner owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Owner_ext owner_ext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PagesItem> pages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int play_param { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pubdate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string redirect_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Rights rights { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Season season { get; set; }
        /// <summary>
        /// 已观看59.2万次
        /// </summary>
        public string share_subtitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string short_link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Stat stat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T_icon t_icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TagItem> tag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// 【1月】DARLING in the FRANXX（僅限港澳台地區） 01
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 连载动画
        /// </summary>
        public string tname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int videos { get; set; }
    }


    public class Bangumi
    {
        /// <summary>
        /// 
        /// </summary>
        public string season_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_jump { get; set; }
        /// <summary>
        /// DARLING in the FRANXX（僅限港澳台地區）
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_finish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newest_ep_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newest_ep_index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string weekday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public User_season user_season { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ogv_play_url { get; set; }
    }

    public class AV
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ver { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lastupdate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lastupdatets { get; set; }
        /// <summary>
        /// 【1月】DARLING in the FRANXX（僅限港澳台地區） 01
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// 连载动画
        /// </summary>
        public string typename { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string created_at { get; set; }
        /// <summary>
        /// 哔哩哔哩番剧出差
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string play { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string coins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string review { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string video_review { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string favorites { get; set; }
        /// <summary>
        /// BILIBILI正版,TV动画
        /// </summary>
        public string tag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public V2_app_api v2_app_api { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Bangumi bangumi { get; set; }
    }
}
