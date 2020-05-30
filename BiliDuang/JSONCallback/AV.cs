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
        public string mid { get; set; }
        /// <summary>
        /// 星系Galaxy-X
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }
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
        /// 我的世界pe奇怪君 《谁动了我的奶酪②》01-放大的仿真世界重新归来！-游戏-高清完整正版视频在线观看-优酷7
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
        /// <summary>
        /// 
        /// </summary>
        public int is_deleted { get; set; }
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
        /// 中文（简体）
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

    public class Data
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
        /// 单机游戏
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
        /// 【我的世界/奇怪君】PE生存《谁动了我的奶酪②》合集（搬运）
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
        /* 视频转载自优酷，用户：@真是奇怪le-奇怪君   后期及字幕：@星系XINGXI
        这个系列我会慢慢更完的，总共18P.希望大家能在这个视频里重温奇怪的生存系列
        字幕工作我会在搬运完毕之前进行，进度的话每天1P.如果有愿意的小伙伴们可以帮忙投稿字幕，这是我第一次搬运视频，如有问题请多多包涵 ~我会争取尽量在4月前落实好字幕的工作......
奇怪是我最初接触的实况主，也是我一直敬仰的一个人，此视频不含任何商业目的，因为暂时没能联系上奇怪君，所以还没有授权
不过这个视频应该也没人看吧......毕竟是很老的视频了，还是1.4版本 ~
 最后UP的QQ：2303628247，愿意帮忙投稿字幕的小伙伴们可以加我（这样进度会加快）*/
        /// </summary>
        public string desc { get; set; }
        public string redirect_url { get; set; }
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
        /// #奇怪君##我的世界##我的世界实况#
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