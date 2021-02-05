using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.tools
{
    class Bcc2srt
    {
        public static string Convert(string bcc)
        {
            bccFile bccfile = JsonConvert.DeserializeObject<bccFile>(bcc);
            int cnt = 0;
            string output = "";
            foreach (bccDialog dialog in bccfile.body)
            {
                DateTime from = new DateTime(long.Parse((double.Parse(dialog.from) * 10000000).ToString()));
                DateTime to = new DateTime(long.Parse((double.Parse(dialog.to) * 10000000).ToString()));
                string fromstr = from.ToString("H:mm:ss,fff");
                string tostr = to.ToString("H:mm:ss,fff");
                output += cnt.ToString() + "\r\n" + fromstr + " --> " + tostr + "\r\n" + dialog.content+"\r\n\r\n";
                cnt++;
            }
            return output;
        }
    }

    struct bccFile
    {
        public List<bccDialog> body { get; set; }
    }

    struct bccDialog
    {
        public string from { get; set; }
        public string to { get; set; }
        public string location { get; set; }
        public string content { get; set; }
    }
}
