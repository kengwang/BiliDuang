namespace BiliDuang.JSONCallback.Intereaction
{
    public class Intereaction
    {
        /// <summary>
        /// 
        /// </summary>
        public int graph_version { get; set; }
        /// <summary>
        /// 登录后才能体验全部结局哦～
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 剧情图被修改已失效
        /// </summary>
        public string error_toast { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int need_reload { get; set; }
    }

}
