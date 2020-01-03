using System.Collections.Generic;

namespace BiliDuang.JSONCallback.AV
{
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

    public class Owner
    {
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 哔哩哔哩番剧
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }
    }

    public class Stat
    {
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
        /// <summary>
        /// 
        /// </summary>
        public string evaluation { get; set; }
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
    }

    public class Subtitle
    {
        /// <summary>
        /// 
        /// </summary>
        public string allow_submit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
    }

    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lan { get; set; }
        /// <summary>
        /// 中文（中国）
        /// </summary>
        public string lan_doc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_lock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subtitle_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Author author { get; set; }
    }

    public class Author
    {
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_fake_account { get; set; }
    }


    public class View
    {
        /// <summary>
        /// 
        /// </summary>
        public string bvid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int videos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// 连载动画
        /// </summary>
        public string tname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int copyright { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 【10月/完结】刀剑神域 爱丽丝篇 异界战争 12
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pubdate { get; set; }
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
        public int state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int attribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
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
        public Owner owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Stat stat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @dynamic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dimension dimension { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string no_cache { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PagesItem> pages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Subtitle subtitle { get; set; }
    }

    public class Level_info
    {
        /// <summary>
        /// 
        /// </summary>
        public int current_level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_min { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_exp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int next_exp { get; set; }
    }

    public class Pendant
    {
        /// <summary>
        /// 
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long expire { get; set; }
    }

    public class Nameplate
    {
        /// <summary>
        /// 
        /// </summary>
        public int nid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image_small { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string condition { get; set; }
    }

    public class Official
    {
        /// <summary>
        /// 
        /// </summary>
        public int role { get; set; }
        /// <summary>
        /// 哔哩哔哩番剧区官方账号
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }

    public class Official_verify
    {
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 哔哩哔哩番剧区官方账号
        /// </summary>
        public string desc { get; set; }
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
        public int theme_type { get; set; }
    }

    public class card
    {
        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 哔哩哔哩番剧
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string approve { get; set; }
        /// <summary>
        /// 男
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DisplayRank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int regtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int spacesta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string place { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int article { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> attentions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fans { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int friend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int attention { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Level_info level_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Pendant pendant { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nameplate nameplate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Official Official { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Official_verify official_verify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Vip vip { get; set; }
    }

    public class Card
    {
        /// <summary>
        /// 
        /// </summary>
        public card card { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string following { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int archive_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int article_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int follower { get; set; }
    }

    public class Count
    {
        /// <summary>
        /// 
        /// </summary>
        public int view { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int use { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int atten { get; set; }
    }

    public class TagsItem
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
        public string head_cover { get; set; }
        /// <summary>
        /// bilibili购买的正版动画，欢迎承包(*￣3￣)╭
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string short_content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Count count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_atten { get; set; }
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
        public int attribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int liked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int hated { get; set; }
    }

    public class Page
    {
        /// <summary>
        /// 
        /// </summary>
        public int acount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
    }

    public class Content
    {
        /// <summary>
        /// 诗乃:我也来交换情报了[画风突变][画风突变][画风突变]
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ipi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int plat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string device { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string members { get; set; }
    }

    public class Folder
    {
        /// <summary>
        /// 
        /// </summary>
        public string has_folded { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_folded { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rule { get; set; }
    }

    public class Up_action
    {
        /// <summary>
        /// 
        /// </summary>
        public string like { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string reply { get; set; }
    }

    public class RepliesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string rpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string oid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string root { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string parent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dialog { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rcount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long floor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fansgrade { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int attr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int like { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string member { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Content content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string replies { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int assist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Folder folder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Up_action up_action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string show_follow { get; set; }
    }

    public class Reply
    {
        /// <summary>
        /// 
        /// </summary>
        public Page page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RepliesItem> replies { get; set; }
    }





    public class RelatedItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int videos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// 完结动画
        /// </summary>
        public string tname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int copyright { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 【合集】药师寺凉子的怪奇事件簿【全13话】
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pubdate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 720P 画质提升 琵琶行字幕 自传 感谢彩虹海压制 田中芳树小说原作改编，凉子SAMA好帅气的说=w=~
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int attribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Rights rights { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Owner owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Stat stat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string @dynamic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dimension dimension { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bvid { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public View View { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Card Card { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TagsItem> Tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Reply Reply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RelatedItem> Related { get; set; }
    }

    public class AV
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