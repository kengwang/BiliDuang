using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using BiliDuang.Apis;
using BiliDuang.Model;
using BiliDuang.View.Pages;

namespace BiliDuang.View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Common.MainWindow = this;
            Utils.Initialize();
            MainFrame.Navigate(new Home());
            // 尝试进行登录
            // 加载用户配置
            LoadUserLoginData();
        }

        public async void UserInfoViewUpdate()
        {
            var json = await BilibiliApi.RequestAsync(BilibiliApis.UserMyInfo);

            if (json["code"].GetValue<int>() == 0 && json["data"]["isLogin"].GetValue<bool>())
            {
                Common.UserInfo = new UserInfo
                {
                    UserName = json["data"]["uname"].ToString(),
                    Uid = json["data"]["mid"].ToString(),
                    AvatarUrl = json["data"]["face"].ToString()
                };
                MainWindowsViewModel.AppBarButtonContent = new Image()
                {
                    Source = new BitmapImage(new Uri(Utils.ImageUrlFormat(Common.UserInfo.AvatarUrl,
                        new() { Format = "jpg" })))
                };
                MainWindowsViewModel.AppBarButtonTooltip = Common.UserInfo.UserName;
            }
        }

        public void LoadUserLoginData()
        {
            if (File.Exists("user.json"))
            {
                try
                {
                    var data =
                        JsonSerializer.Deserialize<UserLoginSavedData>(
                            File.ReadAllText("user.json"));
                    if (data != null)
                    {
                        BilibiliApi.Cookies = new CookieCollection();
                        data.Cookie.ForEach(t => BilibiliApi.Cookies.Add(t));
                        BilibiliApi.AccessKey = data.AccessKey;
                        UserInfoViewUpdate();
                    }
                }
                catch
                {
                    //ignore
                }
            }
        }

        /*
        private static void ModifyTheme()
        {
            bool isDarkTheme = DarkModeToggleButton.IsChecked == true;
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDarkTheme ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }
        */
        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Common.IsLogin)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }
    }
}