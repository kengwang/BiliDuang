using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using BiliDuang.Model;
using Masuit.Tools;
using MaterialDesignThemes.Wpf;

namespace BiliDuang.ViewModel
{
    public sealed class MainWindowsViewModel : DependencyObject
    {
        public static readonly DependencyProperty DrawerListItemsProperty = DependencyProperty.Register(
            "DrawerListItems",
            typeof(ObservableCollection<AvatarListItem>),
            typeof(MainWindowsViewModel),
            new PropertyMetadata(new ObservableCollection<AvatarListItem>()));

        public ObservableCollection<AvatarListItem> DrawerListItems
        {
            get => (ObservableCollection<AvatarListItem>)GetValue(DrawerListItemsProperty);
            set => SetValue(DrawerListItemsProperty, value);
        }

        public static readonly DependencyProperty AppBarButtonContentProperty = DependencyProperty.Register(
            "AppBarButtonContent",
            typeof(UIElement),
            typeof(MainWindowsViewModel),
            new PropertyMetadata(default(UIElement)));

        public UIElement AppBarButtonContent
        {
            get => (UIElement)GetValue(AppBarButtonContentProperty);
            set => SetValue(AppBarButtonContentProperty, value);
        }

        public static readonly DependencyProperty AppBarButtonTooltipProperty = DependencyProperty.Register(
            "AppBarButtonTooltip", typeof(string), typeof(MainWindowsViewModel), new PropertyMetadata(default(string)));

        public string AppBarButtonTooltip
        {
            get => (string)GetValue(AppBarButtonTooltipProperty);
            set => SetValue(AppBarButtonTooltipProperty, value);
        }

        public MainWindowsViewModel()
        {
            DrawerListItems.AddRange(
                new AvatarListItem
                {
                    Icon = PackIconKind.Home,
                    Title = "主页"
                },
                new AvatarListItem()
                {
                    Icon = PackIconKind.Download,
                    Title = "下载"
                },
                new AvatarListItem()
                {
                    Icon = PackIconKind.Settings,
                    Title = "设置"
                });
            AppBarButtonContent = new Image()
            {
                Source = new BitmapImage(new Uri("/Assets/akkarin.jpg",UriKind.Relative))
            };
            AppBarButtonTooltip = "登录";
        }
    }
}