using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BiliDuang.Model;

namespace BiliDuang.View.Component
{
    public partial class VideoWrapPanel : UserControl
    {
        public static readonly DependencyProperty VideosProperty = DependencyProperty.Register(
            "Videos", typeof(ObservableCollection<VideoModel>), typeof(VideoWrapPanel), new PropertyMetadata(default(ObservableCollection<VideoModel>)));

        public ObservableCollection<VideoModel> Videos
        {
            get => (ObservableCollection<VideoModel>)GetValue(VideosProperty);
            set => SetValue(VideosProperty, value);
        }
        public VideoWrapPanel()
        {
            InitializeComponent();
        }
    }
}