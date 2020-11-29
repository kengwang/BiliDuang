using MaterialSkin;
using Microsoft.Win32;
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
            UI.Dialog dialog = new UI.Dialog(t, tt)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            dialog.ShowDialog();
        }

        public static void Show(string t)
        {
            UI.Dialog dialog = new UI.Dialog(t)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            dialog.Show();
        }
    }

    internal class env
    {
        public static MainForm mainForm;
    }

    internal class Other
    {
        /// <summary>
        /// 获取字符串中的数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>数字</returns>
        public static int GetNumberInt(string str)
        {
            int result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d.\d]", "");
                // 如果是数字，则转换为decimal类型
                if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                {
                    result = int.Parse(str);
                }
            }
            return result;
        }

        ///<summary>
        ///取出文本中间内容
        ///<summary>
        ///<param name="left">左边文本</param>
        ///<param name="right">右边文本</param>
        ///<param name="text">全文本</param>
        ///<return>完事返回成功文本|没有找到返回空</return>
        public static string TextGetCenter(string left, string right, string text, string def = "")
        {
            //判断是否为null或者是empty
            if (string.IsNullOrEmpty(left))
            {
                return def;
            }

            if (string.IsNullOrEmpty(right))
            {
                return def;
            }

            if (string.IsNullOrEmpty(text))
            {
                return def;
            }
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
            if (!Settings.autodark)
            {
                return Settings.darkmode;
            }

            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 10)
            {//修改清单值才获取的到 10   https://www.cnblogs.com/lonelyxmas/p/12145320.html
                //获取系统是否深色模式  计算机\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize
                RegistryKey key = Registry.CurrentUser;
                object obj = key.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Themes").OpenSubKey("Personalize").GetValue("AppsUseLightTheme");
                if (obj == null)
                {
                    Settings.darkmode = (DateTime.Now.Hour >= 18 || DateTime.Now.Hour <= 7);
                    return Settings.darkmode;
                }
                else
                {
                    Settings.darkmode = (int)obj == 0;
                    return Settings.darkmode;
                }
            }
            else
            {
                Settings.darkmode = (DateTime.Now.Hour >= 18 || DateTime.Now.Hour <= 7);
                return Settings.darkmode;
            }
        }

        public static void SystemEvents_UserPreferenceChanging(object sender, UserPreferenceChangingEventArgs e)
        {
            if (Settings.autodark)
            {
                RefreshColorSceme();
            }
        }

        public static void RefreshColorSceme()
        {
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            if (Other.IsDarkMode())
            {//Dark Mode
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey900, Primary.Grey700, Primary.Grey700, Accent.Pink100, TextShade.WHITE);
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink100, TextShade.WHITE);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            if (env.mainForm == null || env.mainForm.materialLabel2 == null)
            {
                return;
            }

            env.mainForm.materialLabel2.BackColor = GetBackGroundColor();
        }

        public static Color GetBackGroundColor()
        {
            return IsDarkMode() ? Color.FromArgb(33, 33, 33) : Color.FromArgb(63, 81, 181);
        }
        public static Color GetAccentColor()
        {
            return IsDarkMode() ? Color.FromArgb(255, 128, 171) : Color.FromArgb(255, 128, 171);
        }

        public static string GetHtml(string url, bool withcookie = false)
        {
            string htmlCode;
            HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            webRequest.Timeout = 30000;
            webRequest.Method = "GET";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:75.0) Gecko/20100101 Firefox/75.0";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Referer = "https://www.bilibili.com/";
            if (withcookie)
            {
                webRequest.Headers.Add("Cookie", User.cookie + ";CURRENT_QUALITY=120");
            }

            HttpWebResponse webResponse = (System.Net.HttpWebResponse)webRequest.GetResponse();

            //获取目标网站的编码格式
            string contentype = webResponse.Headers["Content-Type"];
            Regex regex = new Regex("charset\\s*=\\s*[\\W]?\\s*([\\w-]+)", RegexOptions.IgnoreCase);
            if (webResponse.ContentEncoding.ToLower() == "gzip")//如果使用了GZip则先解压
            {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.Compression.GZipStream zipStream = new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
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
            else if(webResponse.ContentEncoding.ToLower() == "deflate") {
                using (System.IO.Stream streamReceive = webResponse.GetResponseStream())
                {
                    using (System.IO.Compression.DeflateStream zipStream = new System.IO.Compression.DeflateStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
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

        public static string HTTPGetXML(string RssUrl)

        {
            Encoding UrlEncoding;
            System.Net.HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(RssUrl);
            hwr.Method = "GET";
            HttpWebResponse hwrp = (HttpWebResponse)hwr.GetResponse();
            UrlEncoding = Encoding.GetEncoding(hwrp.CharacterSet);
            System.IO.Stream ResponseStream = hwrp.GetResponseStream();
            StreamReader oStreamReader = new System.IO.StreamReader(ResponseStream, UrlEncoding);
            string sResult = oStreamReader.ReadToEnd();
            if (hwrp.CharacterSet == "ISO-8859-1") //如果编码为ISO-8859-1才转换
            {
                sResult = ConvertISO88591ToEncoding(sResult, Encoding.Default);
            }

            hwrp.Close();

            //处理RSS返回的数据

            return sResult;

        }

        //转换

        public static string ConvertISO88591ToEncoding(string srcString, Encoding dstEncode)
        {

            string sResult;

            Encoding ISO88591Encoding = Encoding.GetEncoding("ISO-8859-1");
            Encoding GB2312Encoding = Encoding.GetEncoding("gb2312"); //这个地方很特殊，必须利用GB2312编码
            byte[] srcBytes = ISO88591Encoding.GetBytes(srcString);

            //将原本存储ISO-8859-1的字节数组当成GB2312转换成目标编码(关键步骤)
            byte[] dstBytes = Encoding.Convert(GB2312Encoding, dstEncode, srcBytes);

            char[] dstChars = new char[dstEncode.GetCharCount(dstBytes, 0, dstBytes.Length)];

            dstEncode.GetChars(dstBytes, 0, dstBytes.Length, dstChars, 0);//利用char数组存储字符
            sResult = new string(dstChars);
            return sResult;

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
            string[] units = new string[] { "B", "KB", "MB", "GB", "TB", "PB" };
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
