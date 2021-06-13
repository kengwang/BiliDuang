using BiliDuang.tools;
using BiliDuang.VideoClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace BiliDuang
{
    public class DownloadObject
    {
        /**
         * 
         * 正数正常,负数不正常
         *  0 下载未开始 
         *  1 下载排队中
         *  2 下载被手动结束
         *  5 下载开始
         *  6 下载暂停
         *  
         * -1 链接获取错误
         * -2 下载文件错误
         * -3 速度获取报错
         * -4 下载完成报错
         * -5 合并视频报错
         * 
         * 66 下载完成
         */
        public int status = 0;

        public string message;
        private bool wcusing = false;
        public bool handpause;
        private bool cancel = false;
        public int type = 0; // 0 - InnerDownloadObject  1 - Aria2cDownloadObject

        //基本信息
        public string saveto;
        public string aid;
        public string cid;

        public string name
        {
            get => "[" + VideoQuality.Name(quality) + "] " + avname;
            set { return; }
        }

        private string _avname;

        public string avname
        {
            set
            {
                value = value.Replace("\\", "＼");
                value = value.Replace("/", "／");
                value = value.Replace(":", "：");
                value = value.Replace("?", "？");
                value = value.Replace("\"", "＂");
                value = value.Replace("<", "＜");
                value = value.Replace(">", "＞");
                value = value.Replace("|", "｜");
                _avname = value;
            }
            get => _avname;
        }

        public string bilicode; //bilibili 的网页端格式
        public int ischeese = 0;
        public int blocknum = 0;
        public WebClient wc = new WebClient();


        public List<DownloadUrl> urls = new List<DownloadUrl>();
        public int quality;
        private bool single = false;
        private readonly Stopwatch sw = new Stopwatch();

        public int progress; //进度用于进度条
        public double speed;
        private Process ariap;
        internal string ep_id;

        public DownloadObject(string aid, string cid, int quality, string saveto, string name, string avname,
            string bilicode)
        {
            this.aid = aid;
            this.cid = cid;
            this.quality = quality;
            this.saveto = saveto;
            this.name = name;
            this.avname = avname;
            this.bilicode = bilicode;
            type = Settings.usearia2c ? 1 : 0;
        }

        public void LinkStart()
        {
            if (wcusing)
            {
                return;
            }
            else
            {
                wc = new WebClient();
            }

            status = 5;
            if (urls.Count == 0)
            {
                if (!GetDownloadUrls())
                {
                    status = -1;
                    message = "获取下载链接失败";
                    return;
                }
            }

            if (urls.Count == 1)
            {
                single = true;
            }

            //在这里就要先创建好,不然弹幕和字幕会炸
            Directory.CreateDirectory(saveto);
            if (Settings.downloaddanmaku)
                DownloadDanmaku();
            if (Settings.downloadcc)
                DownloadSubtitle();

            if (type == 0)
            {
                //InnerDownload
                try
                {
                    wc.Headers.Add("Cookie", User.cookie);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(CompletedHandle);
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    //wc.Accept = "*/*";
                    //wc.Referer = "https://bilibili.com/";
                    wc.Headers.Add("User-Agent",
                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.13; rv:56.0) Gecko/20100101 Firefox/56.0");
                    wc.Headers.Add("Origin", "https://www.bilibili.com");
                    wc.Headers.Add("Referer", "https://www.bilibili.com");
                    Uri uri = new Uri(urls[blocknum].url);
                    status = 5;
                    if (!single)
                    {
                        Directory.CreateDirectory(saveto + "/" + avname + ".biliduang");
                        message = "开始下载";
                        if (File.Exists(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                        urls[blocknum].type))
                        {
                            FileInfo fi = new FileInfo(saveto + "/" + avname + ".biliduang" + "/" +
                                                       blocknum.ToString() + "." + urls[blocknum].type);
                            if (fi.Length == urls[blocknum].size)
                            {
                                if (!File.Exists(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() +
                                                 "." + urls[blocknum].type + ".aria2"))
                                {
                                    Completed(true, "文件已经存在且大小正确");
                                    return;
                                }
                                else
                                {
                                    File.Delete(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                                urls[blocknum].type);
                                    File.Delete(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                                urls[blocknum].type + ".aria2");

                                    //因为没有用aria2c了,所以删除掉吧
                                } //这里判断是否是Aria2c,它会占用和服务器大小一样的空间                                
                            }
                            else
                            {
                                //这下是真的没下好了
                                File.Delete(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                            urls[blocknum].type);
                            }
                        }

                        Console.WriteLine("Creating Download url: " + urls[blocknum].url + " to " + saveto + "/" +
                                          avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                          urls[blocknum].type);
                        sw.Start();
                        wcusing = true;
                        wc.DownloadFileAsync(uri,
                            saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                            urls[blocknum].type);
                    }
                    else
                    {
                        message = "开始下载";
                        if (File.Exists(saveto + "/" + avname + "." + urls[blocknum].type))
                        {
                            FileInfo fi = new FileInfo(saveto + "/" + avname + "." + urls[blocknum].type);
                            if (fi.Length == urls[blocknum].size)
                            {
                                if (!File.Exists(saveto + "/" + avname + "." + urls[blocknum].type + ".aria2"))
                                {
                                    Completed(true, "文件已经存在且大小正确");
                                    return;
                                }
                                else
                                {
                                    File.Delete(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                                urls[blocknum].type);
                                    File.Delete(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                                urls[blocknum].type + ".aria2");
                                }
                            }
                            else
                            {
                                File.Delete(saveto + "/" + avname + "." + urls[blocknum].type);
                            }
                        }

                        Console.WriteLine("Creating Download url: " + urls[blocknum].url + " to " + saveto + "/" +
                                          avname + " - " + name + "_" + blocknum.ToString() + "." +
                                          urls[blocknum].type);
                        sw.Start();
                        wcusing = true;
                        wc.DownloadFileAsync(uri, saveto + "/" + avname + "." + urls[blocknum].type);
                    }
                }

                catch (WebException we)
                {
                    status = -2;
                    message = "文件分片" + blocknum.ToString() + "下载错误: " + we.Message;
                    wcusing = false;
                }
                catch (System.NotSupportedException e)
                {
                    status = -2;
                    message = e.Message;
                    wcusing = false;
                }
                catch (Exception e)
                {
                    wcusing = false;
                    status = -2;
                    message = "分片" + blocknum.ToString() + "下载错误: " + e.Message;
                }
            }
            else
            {
                //Aria2c
                //{"jsonrpc":"2.0","method":"aria2.addUri","id":"这是啥","params":["token:TOKEN",["链接"],{"dir":"D:\\Myself\\Downloads"}]}
                status = 5;
                if (!single)
                {
                    Directory.CreateDirectory(saveto + "/" + avname + ".biliduang");
                    message = "开始下载";
                    //aria2c可能支持断点续传
                    if (File.Exists(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                    urls[blocknum].type))
                    {
                        FileInfo fi = new FileInfo(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() +
                                                   "." + urls[blocknum].type);
                        if (fi.Length == urls[blocknum].size)
                        {
                            if (!File.Exists(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                             urls[blocknum].type + ".aria2"))
                            {
                                Completed(true, "文件已经存在且大小正确");
                                return;
                            }
                        }
                        //File.Delete(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." + urls[blocknum].type);
                    }

                    Console.WriteLine("Creating Download url by aria2c: " + urls[blocknum].url + " to " + saveto + "/" +
                                      avname + ".biliduang" + "/" + blocknum.ToString() + "." + urls[blocknum].type);

                    DownloadFileByAria2(urls[blocknum].url, saveto + "/" + avname + ".biliduang",
                        blocknum.ToString() + "." + urls[blocknum].type);
                }
                else
                {
                    message = "开始下载";
                    if (File.Exists(saveto + "/" + avname + "." + urls[blocknum].type))
                    {
                        FileInfo fi = new FileInfo(saveto + "/" + avname + "." + urls[blocknum].type);
                        if (fi.Length == urls[blocknum].size)
                        {
                            if (!File.Exists(saveto + "/" + avname + "." + urls[blocknum].type + ".aria2"))
                            {
                                Completed(true, "文件已经存在且大小正确");
                                return;
                            }
                        }
                        //File.Delete(saveto + "/" + avname + "." + urls[blocknum].type);
                    }

                    Console.WriteLine("Creating Download url: " + urls[blocknum].url + " to " + saveto + "/" + avname +
                                      " - " + name + "_" + blocknum.ToString() + "." + urls[blocknum].type);
                    DownloadFileByAria2(urls[blocknum].url, saveto, avname + "." + urls[blocknum].type);
                }
            }
        }

        internal void Resume()
        {
            LinkStart();
        }

        internal void Cancel()
        {
            if (type == 0)
            {
                wcusing = false;
                cancel = true;
                wc.CancelAsync();
                wc.Dispose();
            }
            else
            {
                if (ariap != null && !ariap.HasExited)
                    ariap.Kill();
            }
        }


        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                // 显示下载速度
                speed = Convert.ToDouble(e.BytesReceived) / sw.Elapsed.TotalSeconds;

                if (urls[blocknum].size == -1)
                {
                    urls[blocknum].size = e.TotalBytesToReceive;
                }

                // 进度条
                progress = (e.ProgressPercentage / urls.Count) + (blocknum * 100 / urls.Count);

                // 下载了多少 还剩余多少
                //labelDownloaded.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / 1024).ToString("0.00") + " Mb's" + "  /  " + (Convert.ToDouble(e.TotalBytesToReceive) / 1024 / 1024).ToString("0.00") + " Mb's";
                //正在下载区块 {0}/{5}: {1}/{2}  {3}% 速度:{4}/s <{6}>

                message = string.Format("正在下载区块{0}/{1}: {2}/{3} {4}% 速度:{5}/s <{6}>", blocknum + 1, urls.Count,
                    byteConvert.GetSize(e.BytesReceived), byteConvert.GetSize(e.TotalBytesToReceive),
                    progress.ToString(), byteConvert.GetSize(speed), "NaN");
            }
            catch (Exception ex)
            {
                status = -3;
                message = "进度获取错误" + ex.Message;
            }
        }

        private void CompletedHandle(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                Completed(false, e.Error.Message);
            }
            else
            {
                Completed(true, "下载完成");
            }
        }

        private void Completed(bool complete, string msg)
        {
            wc.Dispose();
            wcusing = false;
            sw.Reset();
            if (status == 1)
            {
                return;
            }

            if (complete != true)
            {
                if (!cancel)
                {
                    status = -4;
                    message = "下载未完成,可能是网络中断,正在重试";
                    Console.WriteLine("下载出错," + msg);
                    LinkStart();
                    return;
                }
            }
            else
            {
                message = "下载完成:" + saveto + avname + " - " + name + "." + urls[blocknum].type;
                if (blocknum != urls.Count - 1)
                {
                    if (single)
                    {
                        FileInfo fi = new FileInfo(saveto + "/" + avname + "." + urls[blocknum].type);
                        Console.WriteLine("Download Complete! Downloaded Size: " + fi.Length.ToString() +
                                          " Server Size: " + urls[blocknum].size.ToString());
                        if (urls[blocknum].size != -1 && fi.Length != urls[blocknum].size)
                        {
                            Console.WriteLine("Size Error, Try Download Again");
                            message = "区块" + (blocknum + 1).ToString() + "下载出错,正在重试";
                            LinkStart();
                            return;
                        }
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() +
                                                   "." + urls[blocknum].type);
                        Console.WriteLine("Download Complete! Downloaded Size: " + fi.Length.ToString() +
                                          " Server Size: " + urls[blocknum].size.ToString());
                        if (urls[blocknum].size != -1 && fi.Length != urls[blocknum].size)
                        {
                            Console.WriteLine("Size Error, Try Download Again");
                            message = "区块" + (blocknum + 1).ToString() + "下载出错,正在重试";
                            LinkStart();
                            return;
                        }
                    }

                    blocknum++;
                    LinkStart();
                    return;
                }
                else if (!single)
                {
                    FileInfo fi = new FileInfo(saveto + "/" + avname + ".biliduang" + "/" + blocknum.ToString() + "." +
                                               urls[blocknum].type);
                    if (fi.Exists && (urls[blocknum].size != -1 && fi.Length != urls[blocknum].size))
                    {
                        Console.WriteLine("Size Error, Try Download Again");
                        message = "区块" + (blocknum + 1).ToString() + "下载出错,正在重试";
                        LinkStart();
                        return;
                    }

                    Console.WriteLine("Download Complete! Downloaded Size: " + fi.Length.ToString() + " Server Size: " +
                                      urls[blocknum].size.ToString());
                    MergeVideo();
                }
                else
                {
                    status = 66;
                    message = "下载完成!";
                }
            }
        }

        private void DownloadSubtitle(string sid = "")
        {
            try
            {
                string playerback = Encoding.UTF8.GetString(
                    new WebClient().DownloadData(string.Format("https://api.bilibili.com/x/player/v2?cid={0}&aid={1}",
                        cid, aid)));
                JSONCallback.SubPlayer.Root playerbackjson =
                    JsonConvert.DeserializeObject<JSONCallback.SubPlayer.Root>(playerback);
                if (playerbackjson.code != 0)
                {
                    Console.WriteLine("下载字幕出错");
                    return;
                }

                string bcc = "";
                if (playerbackjson.data.subtitle.subtitles.Count == 0) return;
                if (playerbackjson.data.subtitle.subtitles.FindIndex((x) => { return x.id == sid; }) != -1)
                {
                    bcc = Encoding.UTF8.GetString(new WebClient().DownloadData("https:" + playerbackjson.data.subtitle
                        .subtitles.Find((x) => { return x.id == sid; }).subtitle_url));
                }
                else
                {
                    bcc = Encoding.UTF8.GetString(
                        new WebClient().DownloadData("https:" +
                                                     playerbackjson.data.subtitle.subtitles[0].subtitle_url));
                }

                File.WriteAllText(saveto + "/" + avname + ".srt", Bcc2srt.Convert(bcc));
            }
            catch (Exception)
            {
            }
        }

        private void DownloadDanmaku()
        {
            try
            {
                message = "正在下载弹幕";
                //1.'https://comment.bilibili.com/' + cid + '.xml'
                //2.'https://api.bilibili.com/x/v1/dm/list.so?oid=' + cid
                string danmakuorigin = Other.GetHtml("https://comment.bilibili.com/" + cid + ".xml");
                //暂时存一下原始弹幕
                File.WriteAllText(saveto + "/" + avname + ".xml", danmakuorigin);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(danmakuorigin);
                if (xml.GetElementsByTagName("state")[0].InnerText != "0")
                {
                    //弹幕出错
                    message = "弹幕下载出错";
                }
                else
                {
                    XmlNodeList xmlNodeList = xml.GetElementsByTagName("d");
                    if (urls[0].width == 0)
                    {
                        switch (quality)
                        {
                            case 120: //4K
                                urls[0].width = 4096;
                                urls[0].height = 2160;
                                break;
                            case 116: //1080P60
                            case 112: //1080P+
                            case 80: //1080P
                                urls[0].width = 1920;
                                urls[0].height = 1080;
                                break;
                            case 74: //720P60
                            case 64: //720P
                                urls[0].width = 1280;
                                urls[0].height = 720;
                                break;
                            case 32: //480P
                                urls[0].width = 720;
                                urls[0].height = 480;
                                break;
                            case 16: //360P
                                urls[0].width = 480;
                                urls[0].height = 360;
                                break;
                        }
                    }

                    string assdmk = DanmakuAss.DanmakuAss.Convert(xmlNodeList, urls[0].width, urls[0].height);
                    File.WriteAllText(saveto + "/" + avname + ".ass", assdmk);
                }
            }
            catch (Exception)
            {
            }
        }

        private void MergeVideo()
        {
            //Goodbye FFMPEG
            message = "合并分块到一个视频文件中";
            if (urls[0].type == "mp4")
            {
                string fc = "";
                List<string> filenames = new List<string>();
                for (int i = 0; i < urls.Count; i++)
                {
                    filenames.Add(saveto + "/" + avname + ".biliduang" + "/" + i + "." + urls[i].type);
                }

                foreach (string file in filenames)
                {
                    fc += string.Format("-add \"{0}\" ", file);
                }

                string argu = string.Format("{0}-new \"{1}\"", fc, (saveto + "/" + avname + "." + urls[0].type));
                Process exep = new Process();
                exep.StartInfo.CreateNoWindow = true;
                exep.StartInfo.Arguments = argu;
                //不使用操作系统使用的shell启动进程
                exep.StartInfo.UseShellExecute = false;
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    exep.StartInfo.FileName = Environment.CurrentDirectory + "/tools/mp4box.exe";
                }
                else
                {
                    exep.StartInfo.FileName = "mp4box";
                }

                exep.Start();
                exep.WaitForExit(); //关键，等待外部程序退出后才能往下执行
                if (File.Exists(saveto + "/" + avname + "." + urls[0].type))
                {
                    try
                    {
                        Directory.Delete(saveto + "/" + avname + ".biliduang", true);
                    }
                    catch (Exception)
                    {
                    }

                    status = 66;
                    message = "下载完成!";
                }
                else
                {
                    status = -5;
                    message = "视频合并出错,下载缓存暂未删除";
                }
            }
            else if (urls[0].type == "flv")
            {
                List<string> filenames = new List<string>();
                for (int i = 0; i < urls.Count; i++)
                {
                    filenames.Add(saveto + "/" + avname + ".biliduang" + "/" + i + "." + urls[i].type);
                }

                if (FlvMerger.StartMerge(filenames, (saveto + "/" + avname + "." + urls[0].type)))
                {
                    if (File.Exists(saveto + "/" + avname + "." + urls[0].type))
                    {
                        Directory.Delete(saveto + "/" + avname + ".biliduang", true);
                        status = 66;
                        message = "下载完成!";
                    }
                    else
                    {
                        status = -5;
                        message = "视频合并出错,下载缓存暂未删除";
                    }
                }
                else
                {
                    status = -5;
                    message = "视频合并出错,下载缓存暂未删除";
                }
            }
        }

        public void Pause()
        {
            if (type == 0)
            {
                status = 6;
                message = "暂停中";
                wcusing = false;
                wc.CancelAsync();
                wc.Dispose();
            }
            else
            {
                if (ariap != null && !ariap.HasExited)
                {
                    ariap.StandardInput.WriteLine("\x3");
                    ariap.Kill();
                }

                status = 6;
                message = "暂停中";
            }
        }

        private bool GetDownloadUrls()
        {
            //重构下载获取 - 2021/6/5
            try
            {
                WebClient webClient = new WebClient();
                string url = "";
                Uri uri;
                if (ischeese == 0) uri = new Uri(Settings.apilink);
                else uri = new Uri("https://api.bilibili.com/pugv/player/web/playurl?fourk=1");
                Dictionary<string, string> getpar = uri.Query.TrimStart('?').Split('&').Select(s =>
                    {
                        var idx = s.IndexOf('=');
                        return new KeyValuePair<string, string>(s.Substring(0, idx), s.Substring(idx + 1));
                    }
                ).ToDictionary(x => x.Key, x => x.Value);

                if (uri.Host.EndsWith(".bilibili.com"))
                {
                    webClient.Headers.Add("Cookie", User.cookie);
                    //不在不适当的地方传递Cookie
                }
                else
                {
                    getpar["area"] = Settings.area;
                }

                //一般参数
                getpar["avid"] = aid;
                getpar["aid"] = aid;
                getpar["cid"] = cid;
                getpar["fourk"] = "1";
                getpar["qn"] = quality.ToString();
                getpar["access_key"] = User.access_key;

                if (Settings.area == "th")
                {
                    //泰国番剧需要
                    getpar["ep_id"] = ep_id;
                }

                if (ischeese != 0)
                {
                    getpar["ep_id"] = ischeese.ToString();
                }

                url = uri.Scheme + "://" + uri.Host + uri.AbsolutePath + "?" +
                      string.Join("&", getpar.Select(x => x.Key + "=" + x.Value));
                System.Net.ServicePointManager.SecurityProtocol |=
                    SecurityProtocolType.Tls12; //适配某些老旧的HTTPS
                string callback = Encoding.UTF8.GetString(webClient.DownloadData(url));
                return PhraseCallback(callback);
            }
            catch (Exception e)
            {
                message = "下载链接获取错误 {0}".Format(e.ToString());
            }


            return false;
        }

        public bool PhraseCallback(string callback)
        {
            try
            {
                //我们要无感判断,免得出问题
                if (string.IsNullOrEmpty(callback)) return false;
                var cbkjson = JsonConvert.DeserializeObject<JObject>(callback);
                if (cbkjson == null) return false;
                if (cbkjson["code"].ToObject<int>() < 0) return false;
                if (cbkjson["result"] != null && cbkjson["result"].ToString() != "suee")
                {
                    quality = cbkjson["result"]["quality"].ToObject<int>();
                    if (cbkjson["result"]["dash"] != null)
                    {
                        //为mp4的dash模式
                        if (cbkjson["result"]["dash"] != null)
                        {
                            urls.Add(new DownloadUrl()
                            {
                                height = cbkjson["result"]["dash"]["video"].ToArray()[0]["height"].ToObject<int>(),
                                width = cbkjson["result"]["dash"]["video"].ToArray()[0]["width"].ToObject<int>(),
                                size = cbkjson["result"]["dash"]["video"].ToArray()[0]["size"].ToObject<long>(),
                                type = cbkjson["result"]["dash"]["video"].ToArray()[0]["mime_type"].ToString()
                                    .Replace("video/", ""),
                                url = cbkjson["result"]["dash"]["video"].ToArray()[0]["base_url"].ToString()
                            });
                            urls.Add(new DownloadUrl()
                            {
                                size = cbkjson["result"]["dash"]["audio"].ToArray()[0]["size"].ToObject<long>(),
                                type = cbkjson["result"]["dash"]["audio"].ToArray()[0]["mime_type"].ToString()
                                    .Replace("audio/", ""),
                                url = cbkjson["result"]["dash"]["audio"].ToArray()[0]["base_url"].ToString()
                            });
                            return true;
                        }
                    }
                }

                if (cbkjson["data"] != null)
                {
                    quality = cbkjson["data"]["quality"].ToObject<int>();
                    if (cbkjson["data"]["durl"] != null)
                    {
                        //flv模式
                        foreach (var jToken in cbkjson["data"]["durl"].ToArray())
                        {
                            urls.Add(new DownloadUrl()
                            {
                                size = jToken["size"].ToObject<long>(),
                                type = "flv",
                                url = jToken["url"].ToString()
                            });
                        }

                        return true;
                    }
                }

                if (cbkjson["result"].ToString() == "suee")
                {
                    //TV解析
                    quality = cbkjson["quality"].ToObject<int>();
                    if (cbkjson["dash"] != null)
                    {
                        //为mp4的dash模式
                        urls.Add(new DownloadUrl()
                        {
                            height = cbkjson["dash"]["video"].ToArray()[0]["height"].ToObject<int>(),
                            width = cbkjson["dash"]["video"].ToArray()[0]["width"].ToObject<int>(),
                            size = -1,
                            type = cbkjson["dash"]["video"].ToArray()[0]["mime_type"].ToString()
                                .Replace("video/", ""),
                            url = cbkjson["dash"]["video"].ToArray()[0]["base_url"].ToString()
                        });
                        urls.Add(new DownloadUrl()
                        {
                            size = -1,
                            type = cbkjson["dash"]["audio"].ToArray()[0]["mime_type"].ToString()
                                .Replace("audio/", ""),
                            url = cbkjson["dash"]["audio"].ToArray()[0]["base_url"].ToString()
                        });
                        return true;
                    }
                    else if (cbkjson["durl"] != null)
                    {
                        //flv模式
                        foreach (var jToken in cbkjson["durl"].ToArray())
                        {
                            urls.Add(new DownloadUrl()
                            {
                                size = jToken["size"].ToObject<long>(),
                                type = "flv",
                                url = jToken["url"].ToString()
                            });
                        }

                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        #region Aria2c下载

        public void DownloadFileByAria2(string url, string directory, string filename)
        {
            string command = Settings.aria2cargument +
                             " --user-agent=\"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:84.0) Gecko/20100101 Firefox/84.0\" --header=\"Origin: https://www.bilibili.com\" --header=\"Referer: https://www.bilibili.com\" -d \"" +
                             directory + "\" -o \"" + filename + "\" \"" + url + "\"";

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                ExecuteAria2c(command, (s, e) => ShowInfo(e.Data));
            }
            else
            {
                ExecuteAria2c(command, (s, e) => ShowInfo(e.Data));
            }
        }

        private void ShowInfo(string outputstr)
        {
            //Console.WriteLine(outputstr);
            if (string.IsNullOrWhiteSpace(outputstr))
            {
                return;
            }

            if (outputstr.Contains("Downloading"))
            {
                status = 5;
            }

            if (outputstr.Contains("Redirecting"))
            {
                message = "正在获取真实下载链接";
                status = 5;
                return;
            }

            if (outputstr.Contains("(OK)"))
            {
                status = 66;
                Completed(true, "下载完成");
            }

            Regex regex = new Regex("\\[#\\S* (\\S*)/(\\S*)\\(([0-9]\\d{0,1})%\\) CN:\\S* DL:(\\S*) ETA:(\\S*)]",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            message = regex.Replace(outputstr, "Aria2c 已下载: $1 / $2 ($3%)  速度: $4/s 剩余时间: $5");
        }

        private void ExecuteAria2c(string argument, DataReceivedEventHandler output)
        {
            ariap = new Process();
            ariap.StartInfo.FileName =
                (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                 (File.Exists("aria2c") || File.Exists("tools/aria2c.exe")))
                    ? "tools/aria2c.exe"
                    : "aria2c";
            ariap.StartInfo.Arguments = argument;

            ariap.StartInfo.CreateNoWindow = true;
            ariap.StartInfo.RedirectStandardError = true;
            ariap.StartInfo.RedirectStandardOutput = true;
            ariap.StartInfo.RedirectStandardInput = true;
            ariap.StartInfo.UseShellExecute = false;


            ariap.OutputDataReceived += output;
            ariap.ErrorDataReceived += output;
            ariap.Exited += (o, e) =>
            {
                if (ariap.ExitCode != 0 || status != 66)
                {
                    status = -5;
                }
            };
            ariap.Start();
            ariap.BeginOutputReadLine();
            ariap.BeginErrorReadLine();
        }

        #endregion
    }

    public class DownloadUrl
    {
        public string type = "flv";
        public string url;
        public long size;
        public int width;
        public int height;
    }
}