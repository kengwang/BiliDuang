using System.Collections.Generic;

namespace BiliDuang.JSONCallback.EdgeInfo
{
    public class Story_listItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int node_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string edge_id { get; set; }
        /// <summary>
        /// 0 片头
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int start_pos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cursor { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public string sar { get; set; }
    }

    public class ChoicesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string platform_action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string native_action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string condition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int text_align { get; set; }
        /// <summary>
        /// A 相信告示牌，继续往前
        /// </summary>
        public string option { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_default { get; set; }
    }

    public class QuestionsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int start_time_r { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pause_video { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ChoicesItem> choices { get; set; }
    }

    public class Skin
    {
        /// <summary>
        /// 
        /// </summary>
        public string choice_image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title_text_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title_shadow_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int title_shadow_offset_y { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int title_shadow_radius { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string progressbar_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string progressbar_shadow_color { get; set; }
    }

    public class Edges
    {
        /// <summary>
        /// 
        /// </summary>
        public Dimension dimension { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<QuestionsItem> questions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Skin skin { get; set; }
    }

    public class VideoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int cid { get; set; }
    }

    public class Preload
    {
        /// <summary>
        /// 
        /// </summary>
        public List<VideoItem> video { get; set; }
    }

    public class Hidden_varsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id_v2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_show { get; set; }
        /// <summary>
        /// 随机值
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int skip_overwrite { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 1 第一循环
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int edge_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Story_listItem> story_list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Edges edges { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Preload preload { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Hidden_varsItem> hidden_vars { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_leaf { get; set; }
    }

    public class EdgeInfo
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
