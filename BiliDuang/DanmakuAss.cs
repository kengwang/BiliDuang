using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BiliDuang.DanmakuAss
{
    class DanmakuAss
    {
        /// <summary>
        /// 将Bilibili弹幕转换为ASS
        /// 作者: Kengwang
        /// </summary>
        /// <see cref="https://github.com/ikde/danmu2ass/blob/master/Danmu2Ass/PythonFile/Niconvert.py"/>
        /// <param name="xmlNodeList"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string Convert(XmlNodeList xmlNodeList, int x, int y)
        {
            string returnstr = @"[Script Info]
ScriptType: v4.00+
Collisions: Normal
PlayResX: " + x.ToString() + @"
PlayResY: " + y.ToString() + @"

[V4+ Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding
Style: BiliDuangDanmaku, Microsoft YaHei, 64, &H00FFFFFF, &H00FFFFFF, &H00000000, &H00000000, 0, 0, 0, 0, 100, 100, 0.00, 0.00, 1, 1, 0, 2, 20, 20, 20, 0

[Events]
Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text
";
            List<DanmakuSingle> danmakulist = new List<DanmakuSingle>();
            try
            {
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    string text = xmlNode.InnerText;
                    string param = xmlNode.Attributes.GetNamedItem("p").InnerText;
                    string[] paramarr = param.Split(',');
                    DanmakuSingle danmaku = new DanmakuSingle
                    {
                        timeoriginal = paramarr[0],
                        type = (DanmakuType)int.Parse(paramarr[1]),
                        fontsize = int.Parse(paramarr[2]),
                        fontcolordec = int.Parse(paramarr[3]),
                        timestamp = long.Parse(paramarr[4]),
                        pool = int.Parse(paramarr[5]),
                        userid = paramarr[6],
                        rowid = long.Parse(paramarr[7]),
                        content = text
                    };
                    int timeint = int.Parse(paramarr[0].Substring(0, paramarr[0].IndexOf('.')));
                    danmaku.timesecond = timeint;
                    string hour = (timeint / 3600).ToString("D2");
                    string minute = ((timeint - (int.Parse(hour) * 3600)) / 60).ToString("D2");
                    string second = ((timeint - (int.Parse(hour) * 3600) - (int.Parse(minute) * 60))).ToString("D2");
                    danmaku.time = hour + ":" + minute + ":" + second + "." + double.Parse(paramarr[0].Substring(paramarr[0].IndexOf(".") - 1)).ToString("F2").Substring(2);
                    danmaku.timeelapse = hour + ":" + minute + ":" + ((timeint - (int.Parse(hour) * 3600) - (int.Parse(minute) * 60)) + 10).ToString("D2") + "." + double.Parse(paramarr[0].Substring(paramarr[0].IndexOf(".") - 1)).ToString("F2").Substring(2);
                    danmaku.fontcolorhex = int.Parse(paramarr[3]).ToString("X6");
                    danmakulist.Add(danmaku);

                }
                danmakulist = danmakulist.OrderBy(d => d.timesecond).ToList();
                Dictionary<int, int> screenrow = new Dictionary<int, int>();//row endtime
                foreach (DanmakuSingle danmaku in danmakulist)
                {//整理为ASS
                    int offset = (System.Text.Encoding.Default.GetByteCount(danmaku.content) / 2) * 5; //一个字节5像素来计算
                    danmaku.startx = x + offset;
                    danmaku.endx = 0 - offset;
                    int nowrow = 1;
                    bool mid = false;
                    while (true)
                    {
                        if (screenrow.ContainsKey(nowrow) && screenrow[nowrow] + 1 > danmaku.timesecond)
                        {
                            //这行有字幕不能占有
                            nowrow++;
                            continue;
                        }
                        else
                        {
                            //可以占用此行                            
                            danmaku.y = nowrow * (y / 12);
                            if (danmaku.y > y) { danmaku.y = (danmaku.y % y) + (mid ? (y / 24) : 0); mid = !mid; }
                            screenrow[nowrow] = danmaku.timesecond;
                            nowrow = 1;
                            break;
                        }
                    }
                    //当前是滚动来的
                    string asssingle = "Dialogue: 3," + danmaku.time + "," + danmaku.timeelapse + ",BiliDuangDanmaku,,0000,0000,0000,," + "{\\move(" + danmaku.startx + ", " + danmaku.y + ", " + danmaku.endx + ", " + danmaku.y + ")\\c&" + danmaku.fontcolorhex + "}" + danmaku.content + "\r\n";
                    returnstr += asssingle;
                }
            }
            catch (Exception)
            {

            }

            return returnstr;
        }
    }

    enum DanmakuType
    {
        None,
        Roll,
        Roll1,
        Roll2,
        Bottom,
        Top,
        MirrorWay,
        Advanced,
        Code,
        BAS
    }

    class DanmakuSingle
    {
        //https://zhidao.baidu.com/question/1430448163912263499.html
        public string timeoriginal;//出现时间 秒为单位
        public DanmakuType type;//弹幕类型
        public int fontsize;//字体大小
        public int fontcolordec;//十进制颜色
        public long timestamp;//发送时间戳
        public int pool;//弹幕池 0普通池 1字幕池 2特殊池 【目前特殊池为高级弹幕专用】
        public string userid;//发送者识别码
        public long rowid;//
        public string content;//内容

        //ASS内容
        public int timesecond;
        public string time;//出现时间,ass格式
        public string timeelapse;//结束时间,ass格式
        public string fontcolorhex;//十六进制颜色
        public int startx, y, endx;

    }
}
