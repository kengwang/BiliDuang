using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BiliDuang.Model
{
    public class VideoModel : DependencyObject
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(VideoModel), new PropertyMetadata(default(string)));

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public static readonly DependencyProperty AvIdProperty = DependencyProperty.Register(
            "AvId", typeof(string), typeof(VideoModel), new PropertyMetadata(default(string)));

        public string AvId
        {
            get => (string)GetValue(AvIdProperty);
            set => SetValue(AvIdProperty, value);
        }

        public static readonly DependencyProperty CidProperty = DependencyProperty.Register(
            "Cid", typeof(string), typeof(VideoModel), new PropertyMetadata(default(string)));

        public string Cid
        {
            get => (string)GetValue(CidProperty);
            set => SetValue(CidProperty, value);
        }

        public static readonly DependencyProperty CoverImageProperty = DependencyProperty.Register(
            "CoverImage", typeof(string), typeof(VideoModel), new PropertyMetadata(default(string)));

        public string CoverImage
        {
            get => (string)GetValue(CoverImageProperty);
            set => SetValue(CoverImageProperty, value);
        }

        public static readonly DependencyProperty QualityProperty = DependencyProperty.Register(
            "Quality", typeof(int), typeof(VideoModel), new PropertyMetadata(116));

        public int Quality
        {
            get => (int)GetValue(QualityProperty);
            set => SetValue(QualityProperty, value);
        }

        public static List<VideoQuality> VideoQualities =>
            new List<VideoQuality>
            {
                new VideoQuality
                {
                    FullName = "240P 极速",
                    ShortName = "240P",
                    Id = 6
                },
                new VideoQuality
                {
                    FullName = "360P 流畅",
                    ShortName = "360P",
                    Id = 16
                },
                new VideoQuality
                {
                    FullName = "480P 清晰",
                    ShortName = "480P",
                    Id = 32
                },
                new VideoQuality
                {
                    FullName = "720P 高清",
                    ShortName = "720P",
                    Id = 64
                },
                new VideoQuality
                {
                    FullName = "720P 60 帧",
                    ShortName = "720P60",
                    Id = 74
                },
                new VideoQuality
                {
                    FullName = "1080P 高清",
                    ShortName = "1080P",
                    Id = 80
                },
                new VideoQuality
                {
                    FullName = "1080P+ 高码率",
                    ShortName = "1080P+",
                    Id = 112
                },
                new VideoQuality
                {
                    FullName = "1080P 60 帧",
                    ShortName = "1080P60",
                    Id = 116
                },
                new VideoQuality
                {
                    FullName = "4K 超清",
                    ShortName = "4K",
                    Id = 120
                },
                new VideoQuality
                {
                    FullName = "HDR 真彩色",
                    ShortName = "HDR",
                    Id = 125
                }
            };

        public class VideoQuality
        {
            public string FullName;
            public string ShortName;
            public int Id;
        }
    }
}