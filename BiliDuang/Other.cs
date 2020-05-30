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

            String sResult;

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






