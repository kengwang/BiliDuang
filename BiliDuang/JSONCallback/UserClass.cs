namespace BiliDuang.JSONCallback.User
{

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
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string due_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vip_pay_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int theme_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Label label { get; set; }
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
        public string expire { get; set; }
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
        /// 
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

    public class Level_exp
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

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 男
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
        public int level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int jointime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int moral { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int silence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int email_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tel_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int identification { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Vip vip { get; set; }
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
        public Official official { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string birthday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_tourist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_fake_account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pin_prompting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Level_exp level_exp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double coins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int following { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int follower { get; set; }
    }

    public class User
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

