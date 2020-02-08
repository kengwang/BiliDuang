using BiliDuang.VideoClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BiliDuang
{

    public class DownloadObject
    {
        /**
         * 正数正常,负数不正常
         * 1 链接获取错误
         * 2 下载文件错误
         * 3 速度获取报错
         * 4 下载完成报错
         * 5 合并视频报错
         */
        public int status = 0;
        public string message;

        //基本信息
        public string saveto;
        public string aid;
        public string cid;
        public string name;


        public List<string> urls = new List<string>();
        public int quality;
        private bool single = false;
        Stopwatch sw = new Stopwatch();

        public int progress;//进度用于进度条
        public double speed;

        public DownloadObject(string aid, string cid, int quality, string saveto, string name)
        {
            this.aid = aid;
            this.cid = cid;
            this.quality = quality;
            this.saveto = saveto;
            this.name = name;
        }

        public void LinkStart()
        {
            status = 0;
            if (!GetDownloadUrls())
            {
                status = -1;
                return;
            }

            for (int i = 0; i < urls.Count; i++)
            {
                /*try
                {*/
                WebClient wc = new WebClient();
                wc.Headers.Add("Cookie", User.cookie);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                sw.Start();
                Uri uri = new Uri(urls[i]);
                if (!single)
                {
                    wc.DownloadFile(uri, saveto + "/" + name + "_" + i.ToString() + ".flv");
                }
                else
                {
                    wc.DownloadFile(uri, saveto + ".flv");
                }
                /*}

               catch (WebException we)
               {
                   status = -2;
                   message = "文件分片" + i.ToString() + "下载错误: " + we.Message;
               }
               catch (Exception e)
               {
                   status = -2;
                   message = "分片" + i.ToString() + "下载错误: " + e.Message;
               }
               */
            }
        }

        internal void Cancel()
        {
            throw new NotImplementedException();
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                // 显示下载速度
                speed = Convert.ToDouble(e.BytesReceived) / 1024 / sw.Elapsed.TotalSeconds;

                // 进度条
                progress = e.ProgressPercentage;

                // 下载了多少 还剩余多少
                //labelDownloaded.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / 1024).ToString("0.00") + " Mb's" + "  /  " + (Convert.ToDouble(e.TotalBytesToReceive) / 1024 / 1024).ToString("0.00") + " Mb's";
                // string.Format("正在下载文件，完成进度{0}/{1}(字节)", e.BytesReceived, e.TotalBytesToReceive);
            }
            catch (Exception ex)
            {
                status = -3;
                message = "进度获取错误" + ex.Message + " 我也不知道为啥会这样";
            }

        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            if (e.Cancelled == true)
            {
                message = "下载未完成,可能是网络中断";
            }
            else
            {
                //TODO
            }
        }

        private bool GetDownloadUrls()
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            MyWebClient.Headers.Add("Cookie", User.cookie);
            string callback = "";
            try
            {
                callback = Encoding.UTF8.GetString(MyWebClient.DownloadData(string.Format("https://api.bilibili.com/x/player/playurl?avid={0}&cid={1}&qn={2}", aid, cid, quality.ToString()))); //如果获取网站页面采用的是UTF-8，则使用这句
            }
            catch (WebException e)
            {
                message = "下载链接获取错误: " + e.Message;
                return false;
            }
            MyWebClient.Dispose();
            JSONCallback.Player.Player player = JsonConvert.DeserializeObject<JSONCallback.Player.Player>(callback);
            if (player.code == -404)
            {
                message = string.Format("无法下载 {0}({1}), 该视频需要大会员登录下载,请先登录", player.code, player.message);
                return false;
            }
            else if (player.code != 0)
            {
                message = string.Format("无法下载 {0}({1})", player.code, player.message);
                return false;
            }
            if (!player.data.accept_quality.Contains(quality))
            {
                Console.WriteLine(string.Format("没有指定的画质 {0} ,最高画质为 {1}, 自动下载最高画质{1}", VideoQuality.Name(quality), VideoQuality.Name(player.data.accept_quality[0])));
                quality = player.data.accept_quality[0];

                WebClient MyWebClient1 = new WebClient();
                MyWebClient1.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                MyWebClient1.Headers.Add("Cookie", User.cookie);
                string callback1 = Encoding.UTF8.GetString(MyWebClient.DownloadData(string.Format("https://api.bilibili.com/x/player/playurl?avid={0}&cid={1}&qn={2}", aid, cid, quality.ToString()))); //如果获取网站页面采用的是UTF-8，则使用这句
                MyWebClient.Dispose();
                player = JsonConvert.DeserializeObject<JSONCallback.Player.Player>(callback1);
            }
            if (player.data.durl.Count == 1)
            {
                single = true;
            }
            foreach (JSONCallback.Player.DurlItem Item in player.data.durl)
            {
                urls.Add(Item.url);
            }
            return true;
        }

    }
}
