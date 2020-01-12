using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace BiliDuang
{

    public class DownloadObject
    {
        public string aid;
        public string DownloadName;
        public string SaveTo;
        public VideoClass.episode parent;
        public List<string> urls;
        private bool _complete = false;
        public bool complete
        {
            set
            {
                _complete = value;
                completeCount++;
                //合并视频文件
                if (urls.Count == completeCount && urls.Count != 1)
                {
                    status = "合并视频文件中";
                    string fc = "";
                    string concat = "\\";
                    if (Environment.OSVersion.Platform == PlatformID.Unix)
                    {
                        concat = "/";
                    }                    
                    for (int i = 0; i < completeCount; i++)
                    {
                        fc += string.Format("file '{0}'" + "\r\n", SaveTo + concat + DownloadName + "_" + i.ToString() + ".flv");
                    }
                    File.WriteAllText(SaveTo + concat + DownloadName + "_files.txt", fc);
                    string argu = string.Format("-y -f concat -safe 0 -i \"{0}\" -c copy \"{1}\"", SaveTo + concat + DownloadName + "_files.txt", SaveTo + concat+ DownloadName + ".flv");
                    Process.Start("ffmpeg", argu).WaitForExit();
                    if (File.Exists(SaveTo + concat + DownloadName + ".flv"))
                    {
                        for (int i = 0; i < completeCount; i++)
                        {
                            File.Delete(SaveTo + "/" + DownloadName + "_" + i.ToString() + ".flv");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < completeCount; i++)
                        {
                            if (!File.Exists(SaveTo + "/" + DownloadName + "_" + i.ToString() + ".flv"))
                            {
                                status = "分片文件丢失,重新下载";
                                parent.Download();
                                Cancel();
                            }
                        }
                        Process.Start("ffmpeg", argu).WaitForExit();
                    }
                    File.Delete(SaveTo + concat + DownloadName + "_files.txt");
                    //DownloadQueue.StartAll();
                    Cancel();
                }
                else if (urls.Count == 1)
                {
                    _complete = value;
                    FStream.Close();
                    File.Move(SaveTo + "/" + DownloadName + "_0.flv", SaveTo + "/" + DownloadName + "_0.flv");
                    //DownloadQueue.StartAll();
                    Cancel();
                }
                else
                {
                    _complete = value;
                }

            }
            get
            {
                return _complete;
            }
        }

        public int completeCount = 0;
        public List<string> filenames = new List<string>();
        private string _status;
        public string status
        {
            get
            {
                if (complete)
                {
                    return "下载完成";
                }
                else if (start && !error && !pause && FStream.CanWrite && myStream.CanRead)
                {
                    string s = string.Format("正在下载区块 {0}/{5}: {1}/{2}  {3}% 速度:{4}/s <{6}>", (completeCount + 1), byteConvert.GetSize(FStream.Length), byteConvert.GetSize(serverFileLength), progress, speed, urls.Count.ToString(), byteConvert.GetSize(downloadedlenthLJ));
                    lastsize = FStream.Length;
                    return s;
                }
                else
                {
                    return _status;
                }
            }
            set
            {
                _status = value;
            }
        }
        private int _progress = 0;
        private long lastsize = 0;
        public int progress
        {
            get
            {
                if (complete)
                {
                    _progress = 100;
                    return 100;
                }
                if (FStream == null || myStream == null)
                {
                    _progress = 0;
                    return 0;
                }

                if (serverFileLength == 0)
                {
                    return 0;
                }
                if (!FStream.CanWrite || !myStream.CanRead)
                {
                    return _progress;
                }
                else
                {
                    _progress = (int)((((Math.Round((double)FStream.Length / (double)serverFileLength, 2)) * 100)) / urls.Count) + (int)((100.0 / urls.Count) * (completeCount));
                }
                if (_progress > 100)
                {
                    return 100;
                }
                return _progress;
            }
        }
        private long _serverFileLength = 0;
        public long serverFileLength
        {
            get
            {
                if (_serverFileLength == 0)
                {
                    _serverFileLength = GetHttpLength(urls[completeCount]);
                }
                return _serverFileLength;
            }
            set
            {
                _serverFileLength = value;
            }
        }
        public long SPosition = 0;
        private string savefilename;
        public bool pause
        {
            get
            {
                if (dthread != null)
                {
                    return !dthread.IsAlive;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool start = false;
        public bool error = false;
        private Thread dthread;
        FileStream FStream = null;
        Stream myStream = null;
        private long lastl;
        private bool downloading;
        private int _losespeed = 0;
        private string speed
        {
            get
            {
                return byteConvert.GetSize(FStream.Length - lastsize);
            }
        }

        private long downloadedlenthLJ => lastl + FStream.Length;

        private long downloadedlenth
        {
            get
            {
                if (FStream.CanWrite)
                {
                    return FStream.Length;
                }
                else
                {
                    return lastl;
                }
            }
        }


        private void Download()
        {
            while (completeCount < urls.Count)
            {
                savefilename = SaveTo + "/" + DownloadName + "_" + completeCount.ToString() + ".flv";
                bool reallyDone = true;
                try
                {
                    Directory.CreateDirectory(SaveTo);
                    //判断要下载的文件夹是否存在
                    if (File.Exists(savefilename))
                    {
                        //打开上次下载的文件
                        FStream = File.OpenWrite(savefilename);
                        //获取已经下载的长度
                        SPosition = FStream.Length;
                        serverFileLength = GetHttpLength(urls[completeCount]);
                        if (serverFileLength == 0)
                        {
                            status = "服务器返回错误!正在重新创建";
                            error = true;
                            parent.Download(SaveTo);
                            
                            return;
                        }
                        Console.WriteLine(string.Format("当前下载 {0} 服务器传回大小 {1}", SPosition.ToString(), serverFileLength.ToString()));
                        if (SPosition == serverFileLength)
                        {//文件是完整的，直接结束下载任务
                            Console.WriteLine("文件是完整的,结束下载");
                            lastl += serverFileLength;
                            if (completeCount == urls.Count - 1) complete = true; else completeCount++;
                            continue;
                        }
                        else if (SPosition >= serverFileLength)
                        {
                            status = "本地数据包损坏,正在尝试重新下载";
                            File.Delete(savefilename);
                            FStream = File.OpenWrite(savefilename);
                            SPosition = 0;
                        }
                        FStream.Seek(SPosition, SeekOrigin.Current);
                    }
                    else
                    {
                        status = "正在创建文件";
                        //文件不保存创建一个文件
                        FStream = new FileStream(savefilename, FileMode.Create);
                        SPosition = 0;

                    }

                    //打开网络连接
                    Console.WriteLine(string.Format("创建到 {0} 的下载链接", urls[completeCount]));
                    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(urls[completeCount]);
                    status = "下载链接获取成功";
                    if (SPosition > 0)
                    {
                        myRequest.AddRange(SPosition);             //设置Range值
                        Console.WriteLine("设置Range到了", SPosition);
                    }

                    //设置Header
                    myRequest.Headers.Add("Cookie", User.cookie);
                    myRequest.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.13; rv:56.0) Gecko/20100101 Firefox/56.0";
                    myRequest.Accept = "*/*";
                    myRequest.Referer = "https://bilibili.com/";
                    myRequest.Headers.Set("Origin", "https://www.bilibili.com");
                    myRequest.KeepAlive = true;

                    //向服务器请求,获得服务器的回应数据流
                    myStream = myRequest.GetResponse().GetResponseStream();
                    status = "创建下载数据流成功";
                    //定义一个字节数据
                    byte[] btContent = new byte[1024];
                    int intSize = 0;
                    intSize = myStream.Read(btContent, 0, 1024);
                    start = true;
                    while (intSize > 0)
                    {
                        FStream.Write(btContent, 0, intSize);
                        intSize = myStream.Read(btContent, 0, 1024);
                    }
                    lastl += serverFileLength;
                    continue;       //返回true下载成功
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233040)
                    {//只是暂停而已
                        status = "暂停";
                    }
                    else
                    {
                        status = "出现错误,正在重试：" + ex.Message;
                        parent.Download(SaveTo);
                        error = true;
                        complete = true;
                    }
                    reallyDone = false;
                }
                finally
                {
                    if (reallyDone)
                    {
                        //关闭流
                        if (myStream != null)
                        {
                            myStream.Close();
                            myStream.Dispose();
                        }
                        if (FStream != null)
                        {
                            FStream.Close();
                            FStream.Dispose();
                        }
                        Console.WriteLine("下载成功");
                        if (completeCount + 1 == urls.Count) complete = true; else completeCount++;
                    }

                }
                continue;
            }
            return;

        }

        static long GetHttpLength(string url)
        {
            long length = 0;
            try
            {
                var req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                req.Headers.Add("Cookie", User.cookie);
                req.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.13; rv:56.0) Gecko/20100101 Firefox/56.0";
                req.Accept = "*/*";
                //req.AddRange(0, 0);
                req.Referer = "https://bilibili.com/";
                req.Headers.Set("Origin", "https://www.bilibili.com");
                req.KeepAlive = true;


                req.Method = "HEAD";
                req.Timeout = 5000;
                var res = (HttpWebResponse)req.GetResponse();
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    length = res.ContentLength;
                }
                res.Close();
                return length;
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }





        public DownloadObject(List<string> urls, string saveto, string MissonName, VideoClass.episode p)
        {
            parent = p;
            this.urls = urls;
            SaveTo = saveto;
            DownloadName = MissonName;
        }

        public void Start()
        {
            dthread = new Thread(new ThreadStart(Download));
            dthread.Start();
            downloading = true;
        }

        public void Pause()
        {
            if (dthread != null)
            {
                if (dthread.IsAlive)
                {
                    dthread.Abort();
                    if (myStream != null)
                    {
                        myStream.Close();
                        myStream.Dispose();
                    }
                    if (FStream != null)
                    {
                        FStream.Close();
                        FStream.Dispose();
                    }

                    downloading = false;
                }
            }
        }


        public void Resume()
        {
            downloading = true;
            dthread = new Thread(new ThreadStart(Download));
            dthread.Start();
        }
        public void Cancel()
        {
            Pause();
            /*foreach (string fn in filenames)
            {
                File.Delete(fn);
            }*/
        }
    }
}
