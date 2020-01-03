using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return Math.Round(size,2) + units[i];
        }



    }
}






