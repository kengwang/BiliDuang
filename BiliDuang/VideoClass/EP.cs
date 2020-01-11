namespace BiliDuang.VideoClass
{
    class EP
    {
        public string epid = "";
        public string ssid;
        public EP(string epid)
        {
            //content="https://www.bilibili.com/bangumi/play/
            string callback = Other.GetHtml("https://www.bilibili.com/bangumi/play/ep" + epid);
            ssid = Other.TextGetCenter("content=\"https://www.bilibili.com/bangumi/play/ss", "/\">", callback);

        }



    }
}
