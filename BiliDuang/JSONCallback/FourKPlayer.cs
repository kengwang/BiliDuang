using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDuang.JSONCallback.FourKPlayer
{
    public class SegmentBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Initialization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string indexRange { get; set; }
    }

    public class Segment_base
    {
        /// <summary>
        /// 
        /// </summary>
        public string initialization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string index_range { get; set; }
    }

    public class VideoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baseUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string base_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> backupUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> backup_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bandwidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mime_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string codecs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string frameRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string frame_rate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startWithSap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int start_with_sap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SegmentBase SegmentBase { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Segment_base segment_base { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int codecid { get; set; }
    }

    public class AudioItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baseUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string base_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> backupUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> backup_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bandwidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mime_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string codecs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string frameRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string frame_rate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startWithSap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int start_with_sap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SegmentBase SegmentBase { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Segment_base segment_base { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int codecid { get; set; }
    }

    public class Dash
    {
        /// <summary>
        /// 
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double minBufferTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double min_buffer_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<VideoItem> video { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AudioItem> audio { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string @from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timelength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accept_format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> accept_description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> accept_quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int video_codecid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string seek_param { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string seek_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dash dash { get; set; }
    }

    public class VideoFrame
    {
    }

    public class FourKPlayer
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ttl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string session { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public VideoFrame videoFrame { get; set; }
    }
}
