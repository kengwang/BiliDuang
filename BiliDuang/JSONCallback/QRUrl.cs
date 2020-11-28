namespace BiliDuang.JSONCallback.QRUrl
{
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string oauthKey { get; set; }
    }

    public class QRUrl
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }

}
