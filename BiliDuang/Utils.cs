using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Masuit.Tools;
using Microsoft.SqlServer.Server;

namespace BiliDuang
{
    public static class Utils
    {
        public static string ImageUrlFormat(string url, ImageFormatOptions options)
        {
            return url + options;
        }

        /// 取出文本中间内容
        /// <param name="left">左边文本</param>
        /// <param name="right">右边文本</param>
        /// <param name="text">全文本</param>
        /// <param name="def">默认值</param>
        /// <return>完事返回成功文本|没有找到返回空</return>
        public static string TextGetCenter(this string text, string left, string right, string def = "")
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
            {
                //判断是否找到left
                return text;
            }

            Lindex = Lindex + left.Length; //取出left右边文本起始位置

            int Rindex = text.IndexOf(right, Lindex); //从left的右边开始寻找right

            if (Rindex == -1)
            {
                //判断是否找到right
                Rindex = text.Length;
            }

            return text.Substring(Lindex, Rindex - Lindex); //返回查找到的文本
        }

        public static string ToHttpString(this CookieCollection cookieCollection)
        {
            string ret = "";
            foreach (Cookie o in cookieCollection)
            {
                ret += o.ToString() + ";";
            }

            return ret;
        }

        #region BV 号转换

        private const string Table = "fZodR9XQDSUm21yCkr6zBqiveYah8bt4xsWpHnJE7jL5VG3guMTKNPAwcF";
        private const int Xor = 177451812;
        private const long Add = 100618342136696320L;
        private static readonly int[] S = { 11, 10, 3, 8, 4, 6, 2, 9, 5, 7 };
        private static readonly Dictionary<char, int> Tr = new();

        public static void Initialize()
        {
            for (var i = 0; i < 58; i++)
            {
                Tr.Add(Table[i], i);
            }
        }

        public static long BV2AV(string x)
        {
            long r = 0;
            for (var i = 0; i < 10; i++)
            {
                r += Tr[x[S[i]]] * (long)Math.Pow(58, i);
            }

            return (r - Add) ^ Xor;
        }

        #endregion

    }

    public class ImageFormatOptions
    {
        public string Width = null;
        public string Height = null;
        public string Format = null;
        public string Quality = null;

        public override string ToString()
        {
            List<string> vars = new List<string>();
            if (Width != null)
                vars.Add(Width + "w");
            if (Height != null)
                vars.Add(Height + "h");
            if (Quality != null)
                vars.Add(Quality + "q");
            string ret = string.Join("_", vars);
            if (Format != null)
                ret += "." + Format;
            if (string.IsNullOrEmpty(ret))
                return ret;
            return "@" + ret;
        }
    }
}