# BiliDuang

Bilibili 视频下载 C# GUI版

Github: https://github.com/kengwang/BiliDuang
	下载 Release: https://github.com/kengwang/BiliDuang/releases/latest

Gitee: https://gitee.com/kengwang/BiliDuang
	下载 Release: https://gitee.com/kengwang/BiliDuang/releases

 ## 请注意
采用Material Design设计 (尽管还是很难看)

特色功能:用户信息获取,用户追番下载,用户收藏夹下载,4K视频下载,港澳台番剧下载,互动视频下载,支持无水印(部分大UP无水印) 支持弹幕下载转换 支持课程下载    

## 免责申明

请勿用于侵犯他人版权用途,作者不负任何责任.

**本软件仅供学习交流使用,下载后请于24小时内删除**

## 项目计划

- [x] 支持用户查询
- [x] 支持港澳台番剧下载
- [x] 支持4K
- [x] 支持互动视频
- [x] 支持断点续传 (可通过 `aria2c` 实现)
- [x] 支持aria2c
- [x] 支持课程下载
- [x] 支持无水印下载



## 使用方法

> 提示:如果遇见无响应,可以选择 `还原此应用` 来不关闭程序继续操作

### 打开

编译后可直接打开

**.NET Framework需>=4.5.0** 非精简版系统已经默认安装

.NET Framework 4.5.1 下载链接:https://www.microsoft.com/zh-cn/download/details.aspx?id=40779

第一次开启速度可能很慢,因为要缓存头像等资源

打开后页面为:

![t1AdW6.png](https://s1.ax1x.com/2020/05/31/t1AdW6.png)

点击右上角的登录即可登录

**注意:登录暂不支持不自动登录,意味着下一次开启软件会自动登录**

点击后可能会弹出脚本错误窗口,比如

![tQxwOP.png](https://s1.ax1x.com/2020/05/31/tQxwOP.png)

我们点击**是**即可

输入账号密码后点击登录按钮登录

稍等片刻您就已经登录了!

![t1AMWV.png](https://s1.ax1x.com/2020/05/31/t1AMWV.png)

如图样式(图片为你的头像)即为登录成功,可以进行接下来的操作

### 下载视频

我写了N种下载方案,针对各种复制过来的网址

目前支持的有

* av号:av170001 , AV170001 , https://bilibili.com/av170001 等格式
* 番剧的av号: av47508491 会自动跳转到 https://www.bilibili.com/bangumi/play/ss4452/
* ep号(哔哩哔哩为每一集番剧设置的号码): ep266609 , https://www.bilibili.com/bangumi/play/ep266609
* ss号(每一季番剧的编号): ss4452 , https://www.bilibili.com/bangumi/play/ss4452/
* md号(番剧介绍页的号码):md24755609 , https://www.bilibili.com/bangumi/media/md24755609
* \***ml号**(收藏夹编号):ml761171511 , https://www.bilibili.com/medialist/detail/ml761171511?type=2
* **BV号**(2020/3/23推出的标准):BV17x411w7KC , https://www.bilibili.com/video/BV17x411w7KC/
* **uid号**(用户编号):uid125526 , https://space.bilibili.com/125526/
* 课程链接: https://www.bilibili.com/cheese/play/ep3247 (**请不要直接输入ep3247**)

*:此方法与其他不一样,在后面会写

#### 普通下载

![t1EFt1.png](https://s1.ax1x.com/2020/05/31/t1EFt1.png)

在文本框中输入ID或网址,点击`Link Start!`或者回车

稍等片刻,即可看到结果

![t1EZ6O.png](https://s1.ax1x.com/2020/05/31/t1EZ6O.png)

##### 单集下载

在想要下载的集中选好清晰度

![t1E1ht.png](https://s1.ax1x.com/2020/05/31/t1E1ht.png)

**清晰度假如选择得太高会自动往下调整**

再点击左边的下载,此时会让你选择下载路径,选择好后即可在`下载管理`看到下载任务

##### 多集下载

选中你要下载的集或者选中全都,点击下载路径按钮来选择下载路径

![t1eXE4.png](https://s1.ax1x.com/2020/05/31/t1eXE4.png)

点击一键设置清晰度标签右边的复选框即可一键更改所有的清晰度

再点击下载选中即可开始下载,在`下载管理`可以看到下载内容

#### 收藏夹下载

输入收藏夹编号,回车或点击按钮,稍等片刻,会弹出一个对话框

![t1mS81.png](https://s1.ax1x.com/2020/05/31/t1mS81.png)

你可以在其中选择直接下载或者查看(以普通AV方式查看)

或者可以选择你要下载的点击下载选中,之后的步骤大同小异

> 注意:您需要关闭此对话框才能操作主窗口!

### 下载管理

![t1mcGR.png](https://s1.ax1x.com/2020/05/31/t1mcGR.png)

> 注意:假如添加后未开启下载,请手动点击 开始下载
>

## 特色功能

### 用户追番查看+下载

登录账户后点击头像,弹出对话框

![t1m2xx.png](https://s1.ax1x.com/2020/05/31/t1m2xx.png)

即可看到你的追番,支持翻页,一页十个,点击下载即可在主窗口 查看下载

### 用户收藏夹下载

在刚才打开的用户信息对话框中,选择`我的收藏夹`

即可看到你的收藏夹

![t1mWM6.png](https://s1.ax1x.com/2020/05/31/t1mWM6.png)

点击查看即可打开查询窗口下载

### 下载列表保存

在你关闭 BiliDuang 时,如果下载列表中有未完成的任务,将会记录下来并在下一次启动时询问是否继续下载

### 解锁区域限制

感谢 [BiliPlus](https://www.biliplus.com/) 提供的 API 接口.

只需要在设置中选择 API 为 `BiliPlus`即可

### 下载无水印

> 请谨慎使用,注意版权问题,引起的纠纷本作者概不负责

在设置中选择API为 `Bilibili TV`即可,请注意,此无水印仅仅针对于部分UP主的视频

目前以测试通过 https://www.bilibili.com/video/BV15y4y1q77G 无水印

### aria2c 下载

> 目前仅为测试版,采用命令行调用的方式.

在设置中勾选 `使用 Aria2c`即可开启aria2c支持,你也可以在后面的文本框中写出你想自定义的参数

注意: 因为Bilibili的限制,所以默认在参数中添加了以下的内容来使下载正常进行

> --user-agent=\"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:84.0) Gecko/20100101 Firefox/84.0\" --header=\"Origin: https://www.bilibili.com\" --header=\"Referer: https://www.bilibili.com\"

而此参数会接在你的自定义参数后面,如有问题可以在 [此Issue](https://github.com/kengwang/BiliDuang/issues/22) 中反馈

### 互动视频

你只需要按照普通下载方式下载视频,比如我要下载 ``BV1UE411y7Wy``

只需在链接搜索框输入`BV1UE411y7Wy`(此处为支持识别的格式)

这时会显示普通的视频分集选择框,但是却没有剧情树等信息.别急,我们只需要点击第一个分P的下载,这时会弹出`互动视频选择框`

> Wow,居然是可视化的,按钮也有定位呢! 好棒棒哦~

![tgN70f.png](https://s1.ax1x.com/2020/06/07/tgN70f.png)

这时你就可以按照一般方式作出选择(点击按钮)

![tgNjpj.png](https://s1.ax1x.com/2020/06/07/tgNjpj.png)

假如选择好剧情,你就可以点击`开始下载`来下载你选择好的剧情视频

假如你对你的选择不满意,你可以选择`重新开始(重置剧情)` 

> 请注意,重置剧情会重置你所选择的所有选择好的剧情视频,如需保存,请先下载!

> 请注意: 目前测试出来 [铁心博弈](https://www.bilibili.com/video/BV1MJ411C7ie) 会出现问题,暂时没有时间去适配

## 进阶操作

### 低缓存模式

在此模式下所有图片都不会显示,也不会主动下载,对于感觉卡顿的可以开启

### API 源

* `Bilibili`:原生API,使用了Bilibili网页 API下载
* `BiliPlus`:使用 [BiliPlus API](https://www.biliplus.com/) ,可以下载港澳台资源 
* `Bilibili TV`: 使用 `Bilibili`的 TV版 的 API接口
* `Bilibili 新版网页端`: 下载下来为mp4文件,但是可能有很多问题

## 感谢

* 感谢各个网站提供的代码提示与API参考

* 本项目使用了[MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin)的[中国修改版](https://gitee.com/victorzhao/MaterialSkin),我在此基础上做了修改
* 本项目使用了[mp4box](https://github.com/gpac/gpac/wiki/MP4Box)

## 注意

该软件遵从 [GPL协议](LICENCE)

1. 请不要闭源此项目
2. 请使用同样许可证
