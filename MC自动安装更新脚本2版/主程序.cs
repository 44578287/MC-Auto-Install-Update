using MC自动安装更新脚本2版.Json;
using MC自动安装更新脚本2版.mods;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static MC自动安装更新脚本2版.mods.配置文件读写;

Console.Title = "快易享MC MOD自动安装&更新";//设置窗口标题

//------------------------------(服务器检测)------------------------------
Console.WriteLine("服务器连接测试");
//if (网络处理.DnsTest())
if (网络处理.TcpSocketTest("445720.xyz"))//检测快易享服务器
{
    Console.WriteLine("服务器连接成功!");
    Console.Clear();//清空屏幕
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;//设置字体颜色
    Console.WriteLine("服务器连接失败!");
    Console.WriteLine("可能是我们服务器出现问题了>_< 或者您可以检查您的网络环境是否正常");
    Console.WriteLine("请联系我们 QQ 小捷:2407896713");
    Console.WriteLine("按任意键退出....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
}
//------------------------------(服务器检测)------------------------------

//------------------------------(设置全局参数)------------------------------
string API请求地址 = "http://mc.445720.xyz:5031/api";

string 当前路径 = System.IO.Directory.GetCurrentDirectory();
string Data文件夹路径 = 当前路径 + "/Data";
string Download文件夹路径 = Data文件夹路径 + "/Download";
string Temp文件夹路径 = Data文件夹路径 + "/Temp";
string Tool文件夹路径 = Data文件夹路径 + "/Tool";
string 配置文件路径 = Data文件夹路径 + "/Config.ini";
string 电脑名称 = Environment.MachineName;
string mac地址 = 网卡.MyMac1();
string 用户名 = Environment.UserName;
//网络处理.IP信息 IP信息= 网络处理.获取IP信息();//获取IP信息
//string 公网IP = IP信息.IP;
bool 初次启动 = true;
//------------------------------(设置全局参数)------------------------------

//------------------------------(目录生成)------------------------------
System.IO.Directory.CreateDirectory(Data文件夹路径);    //创建Data资料夹
System.IO.Directory.CreateDirectory(Download文件夹路径);//创建Download资料夹
System.IO.Directory.CreateDirectory(Temp文件夹路径);    //创建Temp资料夹
System.IO.Directory.CreateDirectory(Tool文件夹路径);    //创建Tool资料夹
//------------------------------(目录生成)------------------------------

//------------------------------(主程序)------------------------------
if (!文本处理.搜索文件(Data文件夹路径, "Config.ini"))//检查Config.ini文件以判断是否为第一次启动
{
    初次启动 = true;
    IniHelper.SetValue("环境参数", "当前路径",当前路径, 配置文件路径);//保存当前路径到配置文件中
}
else
{
    初次启动 = false;
    if (IniHelper.GetValue("环境参数", "当前路径", 当前路径, 配置文件路径) == 当前路径)//判断文件夹是否被移动过
    {
        //Console.WriteLine("没有被移动过");
    }
}

Console.WriteLine("欢迎亲爱的 "+用户名+" 使用MC自动安装&更新器C# 2代");
Console.WriteLine("快易享将与璎珞云网络科技工作室一起创造更多优质项目");
Console.WriteLine("本项目会采集本地用户信息用作优化本项目以及服务器");
Console.WriteLine("请问是否同意?若是不同意将无法继续使用!");
if (!键盘输入.是否循环())
{
    Console.WriteLine("对不起!您不同意上述内容无法继续");
    Console.WriteLine("按任意键退出....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
}

Console.WriteLine("检测本地工具中...");
Console.WriteLine("检测Aria2.exe");
if (File.Exists(Tool文件夹路径+"/aria2.exe"))
{
    Console.WriteLine("Aria2已存在，无需下载");
}
else
{
    运行.CmdDw("https://cloud.445720.xyz/api/v3/file/source/205/aria2.exe?sign=qYUvP1eWFGCNfvTjw6Uogw9jMDLMI1NctJBiPoDx_zM%3D%3A0", Data文件夹路径 + "\\Tool", "aria2.exe");
    Console.WriteLine("Aria2不存在，已下载该文件！");
}
Console.WriteLine("检测Tcping.exe");
if (File.Exists(Tool文件夹路径 + "/Tcping.exe"))
{
    Console.WriteLine("Tcping已存在，无需下载");
}
else
{
    运行.CmdDw("https://cloud.445720.xyz/api/v3/file/source/207/tcping.exe?sign=FY3bet2yoZ6CuYsod7YEwcYh9R3a_efLyGiLO-SQ4Qo%3D%3A0", Data文件夹路径 + "\\Tool", "tcping.exe");
    Console.WriteLine("Tcping不存在，已下载该文件！");
}

Console.WriteLine("以下为目前服务器列表");
string API返回;
try
{
    API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取服务器大纲", 1000);//向服务器发送Get请求,获得服务器大纲
}
catch (System.Net.WebException Message)
{
    Console.ForegroundColor = ConsoleColor.Red;//设置字体颜色
    Console.WriteLine("错误:" + Message);
    Console.WriteLine("可能是我们服务器出现问题了>_< 或者您可以检查您的网络环境是否正常");
    Console.WriteLine("请联系我们 QQ 小捷:2407896713");
    Console.WriteLine("按任意键退出....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
    API返回 = "";
}

List<Json表.服务器大纲> 服务器大纲列表 = new List<Json表.服务器大纲>();

JArray jArray = (JArray)JsonConvert.DeserializeObject(API返回);

for (int i = 0; i < jArray.Count; i++)
{
    JObject JsonData = JObject.Parse(jArray[i].ToString());

    服务器大纲列表.Add(
        new Json表.服务器大纲
        {
            ID = (int)JsonData["id"],
            服务器版本 = (string)JsonData["服务器版本"],
            服务器类型 = (string)JsonData["服务器类型"],
            服务器状态 = (string)JsonData["服务器状态"],
            服务器地址 = new List<string>(Json处理.单层对象数组解析(JsonData.ToString(), "服务器地址")),
            模组ID     = (int)   ((JsonData["服务器整合"])["模组"])["id"],
            模组包名   = (string)((JsonData["服务器整合"])["模组"])["模组包名"],
            光影ID     = (int)   ((JsonData["服务器整合"])["光影"])["id"],
            光影包名   = (string)((JsonData["服务器整合"])["光影"])["光影包名"],
            材质ID     = (int)   ((JsonData["服务器整合"])["材质"])["id"],
            材质包名   = (string)((JsonData["服务器整合"])["材质"])["材质包名"]
        }) ;
    Console.WriteLine("编号:"+i+" ID:"+ 服务器大纲列表[i].ID+ " 服务器版本:" + 服务器大纲列表[i].服务器版本 + " 服务器类型:" + 服务器大纲列表[i].服务器类型 + " 服务器状态:" + 服务器大纲列表[i].服务器状态 + " 服务器模组包名:" + 服务器大纲列表[i].模组包名 + " 服务器光影包名:" + 服务器大纲列表[i].光影包名 + " 服务器材质包名:" + 服务器大纲列表[i].材质包名 + " 服务器地址:" + string.Join(" or ",服务器大纲列表[i].服务器地址));
}


Console.WriteLine("请输入您想要安装的\"编号\"请注意是编号!");

string 选择编号;
int 选择编号int = -1;
do
{
    try
    {
        选择编号 = Console.ReadLine();
        选择编号int = int.Parse(选择编号);
    }
    catch (System.FormatException Messge)
    {
        Console.WriteLine("输入的内容错误");
        continue;
    }
    if (选择编号int < 0)
    {
        Console.WriteLine("输入的编号不在范围");
        选择编号int = -1;
        continue;
    }
    if (选择编号int >= 服务器大纲列表.Count)
    {
        Console.WriteLine("输入的编号不在范围");
        选择编号int = -1;
        continue;
    }
} 
while (选择编号int == -1);

Console.WriteLine("以下为您选择的服务器");
Console.WriteLine("编号:" + 选择编号int + " ID:" + 服务器大纲列表[选择编号int].ID + " 服务器版本:" + 服务器大纲列表[选择编号int].服务器版本 + " 服务器类型:" + 服务器大纲列表[选择编号int].服务器类型 + " 服务器状态:" + 服务器大纲列表[选择编号int].服务器状态 + " 服务器模组包名:" + 服务器大纲列表[选择编号int].模组包名 + " 服务器光影包名:" + 服务器大纲列表[选择编号int].光影包名 + " 服务器材质包名:" + 服务器大纲列表[选择编号int].材质包名 + " 服务器地址:" + string.Join(" or ", 服务器大纲列表[选择编号int].服务器地址));


//-----------------(检测本地是否存在该游戏内容)-----------------
Console.WriteLine("检测本地游戏环境!");

Console.WriteLine("检测是否安装启动器!");

List<Json表.启动器列表> 启动器列表列表 = new List<Json表.启动器列表>();

API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取启动器列表", 1000);//向服务器发送Get请求,获得服务器大纲

jArray = (JArray)JsonConvert.DeserializeObject(API返回);

for (int i = 0; i < jArray.Count; i++)
{
    JObject JsonData = JObject.Parse(jArray[i].ToString());
    启动器列表列表.Add(
        new Json表.启动器列表
        {
            ID = (int)JsonData["id"],
            启动器名称 = (string)JsonData["启动器名称"],
            启动器下载地址 = new List<string>(Json处理.单层对象数组解析(JsonData.ToString(), "启动器下载地址")),
            启动器官网 = (string)JsonData["下载地址"]
        });
}
//Console.WriteLine(启动器列表列表[启动器列表列表.Count-1].ID);//获取ID最大的版本

if (!文本处理.搜索文件(当前路径, "BakaXL*.exe"))
{
    Console.WriteLine("没有找到启动器!开始下载启动器");
    运行.Aria2(启动器列表列表[启动器列表列表[启动器列表列表.Count - 1].ID].启动器下载地址[0], 当前路径, 启动器列表列表[启动器列表列表[启动器列表列表.Count - 1].ID].启动器名称);
    Console.WriteLine("已自动帮您拉起启动器!");
    Console.WriteLine("请您安装完Forge及游戏本体方可继续安装模组");
    Console.WriteLine("安装完便可关闭启动器并进行下一步");
    Process p = Process.Start(启动器列表列表[启动器列表列表[启动器列表列表.Count - 1].ID].启动器名称);
    //Process p = Process.Start("BakaXL" + "*.exe");
    p.WaitForExit();
}
else
{
    Console.WriteLine("找到启动器!");
}

Console.WriteLine("检测是否安装对应版本游戏!");
string Forge位置 = "";

if (文本处理.搜索文件夹回传是否(当前路径 + "\\.minecraft\\versions\\", 服务器大纲列表[选择编号int].服务器版本 + "-forge*"))
{
    Console.WriteLine("找到Forge还有游戏本体!");
    Forge位置 = 文本处理.搜索文件夹回传位置(当前路径 + "\\.minecraft\\versions\\", 服务器大纲列表[选择编号int].服务器版本 + "-forge*");
}
else
{
    Console.WriteLine("没有找到Forge或游戏本体!");
    Console.WriteLine("已自动帮您拉起启动器!");
    Console.WriteLine("请您安装完Forge及游戏本体方可继续安装模组");
    Console.WriteLine("安装完便可关闭启动器并进行下一步");
    Process p = Process.Start(启动器列表列表[启动器列表列表[启动器列表列表.Count - 1].ID].启动器名称);
    //Process p = Process.Start("BakaXL" + "*.exe");
    p.WaitForExit();
    if (!文本处理.搜索文件夹回传是否(当前路径 + "\\.minecraft\\versions\\", 服务器大纲列表[选择编号int].服务器版本 + "-forge*"))
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("好家伙都帮你拉起启动器让你安装游戏了!");
        Console.WriteLine("你不安装游戏我无法帮你安装模组");
        Console.WriteLine("所以你安装玩游戏本体再来找我帮你安装八!");
        Console.WriteLine("按任意键退出....");
        Console.ReadKey(true);
        System.Environment.Exit(0);
    }
}

//-----------------(检测本地是否存在该游戏内容)-----------------



//-----------------(获取选定服务器详细内容)-----------------
Console.WriteLine("以下为当前选择服务器模组包信息");

API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取模组列表", 1000);//向服务器发送Get请求,获得服务器大纲

List<Json表.模组列表> 模组列表列表 = new List<Json表.模组列表>();

jArray = (JArray)JsonConvert.DeserializeObject(API返回);

for (int i = 0; i < jArray.Count; i++)
{
    JObject JsonData = JObject.Parse(jArray[i].ToString());
    模组列表列表.Add(
        new Json表.模组列表
        {
            ID = (int)JsonData["id"],
            适用服务器版本 = (string)JsonData["适用服务器版本"],
            模组包名 = (string)JsonData["模组包名"],
            模组内容 = new List<string>(Json处理.单层对象数组解析(JsonData.ToString(), "模组内容")),
            打包日期 = (string)JsonData["打包日期"],
            下载地址 = (string)JsonData["下载地址"]
        });
    //Console.WriteLine("编号:"+i+" ID:" + 模组列表列表[i].ID + " 适用服务器版本:" + 模组列表列表[i].适用服务器版本 + " 模组包名:" + 模组列表列表[i].模组包名 + "\r\n模组内容:\r\n" + string.Join("\r\n", 模组列表列表[i].模组内容) + "\r\n打包日期:" + 模组列表列表[i].打包日期 + " 下载地址:" + 模组列表列表[i].下载地址);
}
Console.WriteLine("ID:" + 模组列表列表[服务器大纲列表[选择编号int].模组ID].ID + " 适用服务器版本:" + 模组列表列表[服务器大纲列表[选择编号int].模组ID].适用服务器版本 + " 模组包名:" + 模组列表列表[服务器大纲列表[选择编号int].模组ID].模组包名 + "\r\n模组内容:\r\n" + string.Join("\r\n", 模组列表列表[服务器大纲列表[选择编号int].模组ID].模组内容) + "\r\n打包日期:" + 模组列表列表[服务器大纲列表[选择编号int].模组ID].打包日期 + " 下载地址:" + 模组列表列表[服务器大纲列表[选择编号int].模组ID].下载地址);


Console.WriteLine("以下为当前选择服务器光影包信息");

API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取光影列表", 1000);//向服务器发送Get请求,获得服务器大纲

List<Json表.光影列表> 光影列表列表 = new List<Json表.光影列表>();

jArray = (JArray)JsonConvert.DeserializeObject(API返回);

for (int i = 0; i < jArray.Count; i++)
{
    JObject JsonData = JObject.Parse(jArray[i].ToString());
    光影列表列表.Add(
        new Json表.光影列表
        {
            ID = (int)JsonData["id"],
            适用服务器版本 = (string)JsonData["适用服务器版本"],
            光影包名 = (string)JsonData["光影包名"],
            光影内容 = new List<string>(Json处理.单层对象数组解析(JsonData.ToString(), "光影内容")),
            打包日期 = (string)JsonData["打包日期"],
            下载地址 = (string)JsonData["下载地址"]
        });
    //Console.WriteLine("编号:" + i + " ID:" + 光影列表列表[i].ID + " 适用服务器版本:" + 光影列表列表[i].适用服务器版本 + " 光影包名:" + 光影列表列表[i].光影包名 + "\r\n光影内容:\r\n" + string.Join("\r\n", 光影列表列表[i].光影内容) + "\r\n打包日期:" + 光影列表列表[i].打包日期 + " 下载地址:" + 光影列表列表[i].下载地址);
}
Console.WriteLine(" ID:" + 光影列表列表[服务器大纲列表[选择编号int].光影ID].ID + " 适用服务器版本:" + 光影列表列表[服务器大纲列表[选择编号int].光影ID].适用服务器版本 + " 光影包名:" + 光影列表列表[服务器大纲列表[选择编号int].光影ID].光影包名 + "\r\n光影内容:\r\n" + string.Join("\r\n", 光影列表列表[服务器大纲列表[选择编号int].光影ID].光影内容) + "\r\n打包日期:" + 光影列表列表[服务器大纲列表[选择编号int].光影ID].打包日期 + " 下载地址:" + 光影列表列表[服务器大纲列表[选择编号int].光影ID].下载地址);




Console.WriteLine("以下为当前选择服务器材质包信息");

API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取材质列表", 1000);//向服务器发送Get请求,获得服务器大纲

List<Json表.材质列表> 材质列表列表 = new List<Json表.材质列表>();

jArray = (JArray)JsonConvert.DeserializeObject(API返回);

for (int i = 0; i < jArray.Count; i++)
{
    JObject JsonData = JObject.Parse(jArray[i].ToString());
    材质列表列表.Add(
        new Json表.材质列表
        {
            ID = (int)JsonData["id"],
            适用服务器版本 = (string)JsonData["适用服务器版本"],
            材质包名 = (string)JsonData["材质包名"],
            材质内容 = new List<string>(Json处理.单层对象数组解析(JsonData.ToString(), "材质内容")),
            打包日期 = (string)JsonData["打包日期"],
            下载地址 = (string)JsonData["下载地址"]
        });
    //Console.WriteLine("编号:" + i + " ID:" + 材质列表列表[i].ID + " 适用服务器版本:" + 材质列表列表[i].适用服务器版本 + " 材质包名:" + 材质列表列表[i].材质包名 + "\r\n材质内容:\r\n" + string.Join("\r\n", 材质列表列表[i].材质内容) + "\r\n打包日期:" + 材质列表列表[i].打包日期 + " 下载地址:" + 材质列表列表[i].下载地址);
}
Console.WriteLine(" ID:" + 材质列表列表[服务器大纲列表[选择编号int].材质ID].ID + " 适用服务器版本:" + 材质列表列表[服务器大纲列表[选择编号int].材质ID].适用服务器版本 + " 材质包名:" + 材质列表列表[服务器大纲列表[选择编号int].材质ID].材质包名 + "\r\n材质内容:\r\n" + string.Join("\r\n", 材质列表列表[服务器大纲列表[选择编号int].材质ID].材质内容) + "\r\n打包日期:" + 材质列表列表[服务器大纲列表[选择编号int].材质ID].打包日期 + " 下载地址:" + 材质列表列表[服务器大纲列表[选择编号int].材质ID].下载地址);
//-----------------(获取选定服务器详细内容)-----------------


Console.WriteLine("请问是否更新模组?(y/n)");
bool 更新模组 = 键盘输入.是否默认是();
Console.WriteLine("请问是否更新材质?(y/n)");
bool 更新材质 = 键盘输入.是否默认是();
Console.WriteLine("请问是否更新光影?(y/n)");
bool 更新光影 = 键盘输入.是否默认是();


//-----------------(下载相应文件)-----------------
if (更新模组)
{
    if (文本处理.搜索文件(Download文件夹路径, 模组列表列表[服务器大纲列表[选择编号int].模组ID].模组包名))
    {
        Console.WriteLine("文件已存在，无需下载");
    }
    else
    {
        运行.Aria2(模组列表列表[服务器大纲列表[选择编号int].模组ID].下载地址, Download文件夹路径 , 模组列表列表[服务器大纲列表[选择编号int].模组ID].模组包名);
        Console.WriteLine("文件不存在，已下载该文件！");
    }
}

if (更新材质)
{
    if (文本处理.搜索文件(Download文件夹路径, 材质列表列表[服务器大纲列表[选择编号int].材质ID].材质包名))
    {
        Console.WriteLine("文件已存在，无需下载");
    }
    else
    {
        运行.Aria2(材质列表列表[服务器大纲列表[选择编号int].材质ID].下载地址, Download文件夹路径, 材质列表列表[服务器大纲列表[选择编号int].材质ID].材质包名);
        Console.WriteLine("文件不存在，已下载该文件！");
    }
}

if (更新光影)
{
    if (文本处理.搜索文件(Download文件夹路径, 光影列表列表[服务器大纲列表[选择编号int].光影ID].光影包名))
    {
        Console.WriteLine("文件已存在，无需下载");
    }
    else
    {
        运行.Aria2(光影列表列表[服务器大纲列表[选择编号int].光影ID].下载地址, Download文件夹路径, 光影列表列表[服务器大纲列表[选择编号int].光影ID].光影包名);
        Console.WriteLine("文件不存在，已下载该文件！");
    }
}
//-----------------(下载相应文件)-----------------


//-----------------(解压并移动)-----------------
string 模组安装位置 = Forge位置 + "/mods";
string 材质安装位置 = Forge位置 + "/resourcepacks";
string 光影安装位置 = Forge位置 + "/shaderpacks";

if (更新模组)
{
    Console.WriteLine("解压并复制模组");
    System.IO.Directory.CreateDirectory(模组安装位置);//创建模组资料夹
    System.IO.Directory.Delete(模组安装位置,true);//删除资料夹
    System.IO.Directory.CreateDirectory(模组安装位置);//创建模组资料夹
    运行.万能解压(Download文件夹路径 + "/" + 模组列表列表[服务器大纲列表[选择编号int].模组ID].模组包名 , Temp文件夹路径);
    文本处理.移动文件夹下内容到别的文件夹下(Temp文件夹路径 + "/mods", 模组安装位置);
    Console.WriteLine("模组安装完成");
}
if (更新材质)
{
    Console.WriteLine("解压并复制材质");
    System.IO.Directory.CreateDirectory(材质安装位置);//创建材质资料夹
    System.IO.Directory.Delete(材质安装位置,true);//删除资料夹
    System.IO.Directory.CreateDirectory(材质安装位置);//创建材质资料夹
    运行.万能解压(Download文件夹路径 + "/" + 材质列表列表[服务器大纲列表[选择编号int].材质ID].材质包名 , Temp文件夹路径);
    文本处理.移动文件夹下内容到别的文件夹下(Temp文件夹路径 + "/resourcepacks", 材质安装位置);
    Console.WriteLine("材质安装完成");
}
if (更新光影)
{
    Console.WriteLine("解压并复制光影");
    System.IO.Directory.CreateDirectory(光影安装位置);//创建光影资料夹
    System.IO.Directory.Delete(光影安装位置,true);//删除资料夹
    System.IO.Directory.CreateDirectory(光影安装位置);//创建光影资料夹
    运行.万能解压(Download文件夹路径 + "/" + 光影列表列表[服务器大纲列表[选择编号int].光影ID].光影包名, Temp文件夹路径);
    文本处理.移动文件夹下内容到别的文件夹下(Temp文件夹路径 + "/shaderpacks", 光影安装位置);
    Console.WriteLine("光影安装完成");
}

//-----------------(解压并移动)-----------------


//-----------------(结尾)-----------------
Console.Clear();
Console.WriteLine("安装完成!");

Console.WriteLine("当前选择服务器有"+ 服务器大纲列表[选择编号int].服务器地址.Count + "个节点可供选择");
Console.WriteLine("以下为节点列表:");
for (int i = 0; i < 服务器大纲列表[选择编号int].服务器地址.Count; i++)
{
    Console.WriteLine(服务器大纲列表[选择编号int].服务器地址[i]);
}
Console.WriteLine("开始自动帮您测试节点延迟");

List<运行.节点延迟> 延迟列表 = new List<运行.节点延迟> { };

List<float> 平均延迟 = new List<float> { };

for (int i = 0; i < 服务器大纲列表[选择编号int].服务器地址.Count; i++)
{
    string[] Ping原地址 =服务器大纲列表[选择编号int].服务器地址[i].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
    string Ping地址;
    try 
    { 
        Ping地址 = Ping原地址[0] + " " + Ping原地址[1]; 
    }
    catch (System.IndexOutOfRangeException ex)
    {
        Ping地址 = 服务器大纲列表[选择编号int].服务器地址[i];
    }
    string[] sArray = 运行.Ping2(Ping地址).Split(new string[] { "=", "ms", "(", "fail)" }, StringSplitOptions.RemoveEmptyEntries);
    if (sArray.Length == 11)
    {
        延迟列表.Add
                    (new 运行.节点延迟 
                    {
                        Ping = "无法连接，无法提供行程统计 - 1",
                        平均延迟 = "99999.99",
                        丢包率 = sArray[9]
                    });
    }
    else
    {
        延迟列表.Add
                    (new 运行.节点延迟
                    {
                        Ping = sArray[15],
                        平均延迟 = float.Parse(sArray[15]).ToString(),
                        丢包率 = sArray[9]
                    });
    }
    Console.WriteLine("节点:"+ 服务器大纲列表[选择编号int].服务器地址[i] +" 平均延迟:"+ 延迟列表[i].平均延迟+"ms 丢包率:"+ 延迟列表[i].丢包率);

    平均延迟.Add(float.Parse(延迟列表[i].平均延迟));
}


for (int i = 0; i < 服务器大纲列表[选择编号int].服务器地址.Count; i++)
{
    if (平均延迟.Min() == float.Parse(延迟列表[i].平均延迟) && 平均延迟.Min() != (float)99999.99)
    {
        Console.WriteLine("推荐使用节点:"+ 服务器大纲列表[选择编号int].服务器地址[i] + " 平均延迟为:"+ 延迟列表[i].平均延迟+"ms");
        break;
    }
    else if (平均延迟.Min() == (float)99999.99)
    {
        Console.WriteLine("服务器可能出现故障请联系管理员");
        Console.WriteLine("@ck呵呵,QQ:2407896713");
        break;
    }
}


Console.WriteLine("快易享主站 https://445720.xyz");
Console.WriteLine("快易享网盘 https://cloud.445720.xyz 提供下载服务");
Console.WriteLine("快易享MC   https://mc.445720.xyz    提供游戏服务器");
Console.WriteLine("本工具由@ck小捷所编写,欢迎交流使用");
Console.WriteLine("QQ:2407896713 @ck呵呵");
Console.WriteLine("按任意键退出,感谢您的安装与支持!!!");

Console.ReadKey(true);

//-----------------(结尾)-----------------


//------------------------------(主程序)------------------------------