using System.Windows;

namespace BiliDuang.Model
{
    public class UserInfo : DependencyObject
    {
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
            "UserName", typeof(string), typeof(UserInfo), new PropertyMetadata(default(string)));

        public string UserName
        {
            get => (string)GetValue(UserNameProperty);
            set => SetValue(UserNameProperty, value);
        }

        public static readonly DependencyProperty UidProperty = DependencyProperty.Register(
            "Uid", typeof(string), typeof(UserInfo), new PropertyMetadata(default(string)));

        public string Uid
        {
            get => (string)GetValue(UidProperty);
            set => SetValue(UidProperty, value);
        }

        public static readonly DependencyProperty AvatarUrlProperty = DependencyProperty.Register(
            "AvatarUrl", typeof(string), typeof(UserInfo), new PropertyMetadata(default(string)));

        public string AvatarUrl
        {
            get => (string)GetValue(AvatarUrlProperty);
            set => SetValue(AvatarUrlProperty, value);
        }
    }
}
