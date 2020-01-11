using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BiliDuang
{

    public class Dialog
    {
        public static void Show(string t, string tt)
        {
            UI.Dialog dialog = new UI.Dialog(t, tt);
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        public static void Show(string t)
        {
            UI.Dialog dialog = new UI.Dialog(t);
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.Show();
        }
    }

    class env
    {
        public static MainForm mainForm;
    }

    class Other
    {
        ///<summary>
        ///取出文本中间内容
        ///<summary>
        ///<param name="left">左边文本</param>
        ///<param name="right">右边文本</param>
        ///<param name="text">全文本</param>
        ///<return>完事返回成功文本|没有找到返回空</return>
        public static string TextGetCenter(string left, string right, string text)
        {
            //判断是否为null或者是empty
            if (string.IsNullOrEmpty(left))
                return text;
            if (string.IsNullOrEmpty(right))
                return text;
            if (string.IsNullOrEmpty(text))
                return text;
            //判断是否为null或者是empty

            int Lindex = text.LastIndexOf(left); //搜索left的位置

            if (Lindex == -1)
            { //判断是否找到left
                return text;
            }

            Lindex = Lindex + left.Length; //取出left右边文本起始位置

            int Rindex = text.IndexOf(right, Lindex);//从left的右边开始寻找right

            if (Rindex == -1)
            {//判断是否找到right
                Rindex = text.Length;
            }

            return text.Substring(Lindex, Rindex - Lindex);//返回查找到的文本
        }
        public static bool IsDarkMode()
        {
            return (DateTime.Now.Hour >= 19 || DateTime.Now.Hour <= 8);
        }

        public static Color GetBackGroundColor()
        {
            return IsDarkMode() ? Color.FromArgb(96, 125, 139) : Color.FromArgb(63, 81, 181);
        }


        public static string GetHtml(string url)
        {
            string htmlCode;
            HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            webRequest.Timeout = 30000;
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/4.0";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");


            HttpWebResponse webResponse = (System.Net.HttpWebResponse)webRequest.GetResponse();

            //获取目标网站的编码格式
            string contentype = webResponse.Headers["Content-Type"];
            Regex regex = new Regex("charset\\s*=\\s*[\\W]?\\s*([\\w-]+)", RegexOptions.IgnoreCase);
            if (webResponse.ContentEncoding.ToLower() == "gzip")//如果使用了GZip则先解压
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (var zipStream = new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
                    {

                        //匹配编码格式
                        if (regex.IsMatch(contentype))
                        {
                            Encoding ending = Encoding.GetEncoding(regex.Match(contentype).Groups[1].Value.Trim());
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, ending))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.UTF8))
                            {
                                htmlCode = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            else
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.Default))
                    {
                        htmlCode = sr.ReadToEnd();
                    }
                }
            }
            return htmlCode;
        }
    }


    public class byteConvert
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>


        public static string GetSize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size, 2) + units[i];
        }



    }
}






