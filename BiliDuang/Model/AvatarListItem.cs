using System.Windows;
using MaterialDesignThemes.Wpf;

namespace BiliDuang.Model
{
    public class AvatarListItem : DependencyObject
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(PackIconKind), typeof(AvatarListItem), new PropertyMetadata(default(PackIconKind)));

        public PackIconKind Icon
        {
            get => (PackIconKind)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(AvatarListItem), new PropertyMetadata(default(string)));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
    }
}