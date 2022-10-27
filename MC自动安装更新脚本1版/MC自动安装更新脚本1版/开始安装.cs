using System.Diagnostics;
//using System.Net.NetworkInformation;
using exe类;
using net类;
using 文本类;
using 输入类;

string 当前路径 = System.IO.Directory.GetCurrentDirectory();

Console.Title = "快易享MC 自动安装&更新";


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("欢迎使用MC自动安装更新脚本C#重构版");

string 年月日= DateTime.Now.ToLongDateString().ToString();
string 时分秒= DateTime.Now.ToString("hh时mm分ss秒");
string 电脑名称 = Environment.MachineName;
string mac地址 = net.MyMac1();

Console.WriteLine("本机名称:"+电脑名称);
Console.WriteLine("当前时间:"+年月日 + 时分秒);
Console.WriteLine("本机地址:"+mac地址);

Console.WriteLine("创建tool资料夹");
System.IO.Directory.CreateDirectory(当前路径+"/tool");
Console.WriteLine("创建data资料夹");
System.IO.Directory.CreateDirectory(当前路径 + "/data");

Console.WriteLine("检测工具.....");

Console.WriteLine("检测aria2.exe");
string exename = "aria2.exe";
if (File.Exists(当前路径 + "/tool/"+exename)) 
{
    Console.WriteLine("文件已存在，无需下载");
}
else
{
    exe.CmdDw("https://cloud.445720.xyz/api/v3/file/source/205/aria2.exe?sign=qYUvP1eWFGCNfvTjw6Uogw9jMDLMI1NctJBiPoDx_zM%3D%3A0", 当前路径+ "\\tool", "aria2.exe");
    Console.WriteLine("文件不存在，已下载该文件！");
}

Console.WriteLine("检测WinRAR.exe");
exename = "WinRAR.exe";
if (File.Exists(当前路径 + "/tool/" + exename))
{
    Console.WriteLine("文件已存在，无需下载");
}
else
{
    exe.Aria2("https://cloud.445720.xyz/api/v3/file/source/204/WinRAR.exe?sign=v7iIJ4F46fmiAYwjZ8a64CNkcBdl9DkLnMtIK2wiV7s%3D%3A0", 当前路径 + "\\tool", "WinRAR.exe");
    Console.WriteLine("文件不存在，已下载该文件！");
}

Console.WriteLine("检测tcping.exe");
exename = "tcping.exe";
if (File.Exists(当前路径 + "/tool/" + exename))
{
    Console.WriteLine("文件已存在，无需下载");
}
else
{
    exe.Aria2("https://cloud.445720.xyz/api/v3/file/source/207/tcping.exe?sign=FY3bet2yoZ6CuYsod7YEwcYh9R3a_efLyGiLO-SQ4Qo%3D%3A0", 当前路径 + "\\tool", "tcping.exe");
    Console.WriteLine("文件不存在，已下载该文件！");
}

exe.CmdDw("http://mc.445720.xyz:8877/模组信息.txt", 当前路径 + "\\data", "模组信息.txt");

Console.Clear();

Console.WriteLine("下载模组信息");

Console.WriteLine("解析模组信息");
string []模组信息= 文本处理.字串关键字分割(文本处理.读取(当前路径 + "\\data\\模组信息.txt"), "\"");
Console.WriteLine("当前服务器-模组-版本:" + 模组信息[1]);
string 模组地址 = 模组信息[3];
Console.WriteLine("当前服务器-材质-版本:" + 模组信息[5]);
string 材质地址 = 模组信息[7];
Console.WriteLine("当前服务器-光影-版本:" + 模组信息[9]);
string 光影地址 = 模组信息[11];
Console.WriteLine("启动器-版本:" + 模组信息[13]);
string 启动器地址 = 模组信息[15];


Console.WriteLine("检测是否安装启动器");
if(文本处理.搜索文件(当前路径, "BakaXL*.exe"))
{
    Console.WriteLine("找到启动器!将继续安装");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("EMMM我好像没找到启动器耶");
    Console.WriteLine("请把本工具放在启动器根目录");
    Console.WriteLine("呐这是启动器的官网  https://www.bakaxl.com/");
    Console.WriteLine("需要帮你下载启动器吗?(y/n)默认y");
    if(输入.是否默认是())
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("开始下载启动器");
        exe.Aria2(启动器地址, 当前路径 , "BakaXL.exe");
        Console.WriteLine("已自动帮您拉起启动器!");
        Console.WriteLine("请您安装完Forge及游戏本体方可继续安装模组");
        Process p = Process.Start("BakaXL.exe");
        p.WaitForExit();
        if (文本处理.搜索文件夹回传是否(当前路径 + "\\.minecraft", "versions")) 
        {
            Console.WriteLine("找到游戏安装位置将继续");
        }
        else
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
}

Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("开始自动安装");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("注意!接下来会删除掉模组,材质,光影资料夹中的所有资料!!!");
Console.WriteLine("注意!接下来会删除掉模组,材质,光影资料夹中的所有资料!!!");
Console.WriteLine("注意!接下来会删除掉模组,材质,光影资料夹中的所有资料!!!");
Console.WriteLine("没有选择的安装项目则不影响");
Console.WriteLine("请问是否继续?(y/n)");
if(输入.是否循环())
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("好还有一些问题....");
}
else
{
    Console.WriteLine("取消安装!谢谢使用本工具");
    Console.WriteLine("按任意键退出....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
}

if (文本处理.搜索文件夹回传是否(当前路径 + "\\.minecraft\\","versions"))
{
    Console.WriteLine("找到游戏安装目录");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("大哥找不到游戏目录啊!你是不是没有安装forge跟游戏?");
    Console.WriteLine("请先安装forge跟游戏欧在使用本工具欧!");
    Console.WriteLine("本程序将退出");
    Console.WriteLine("按任意键退出....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
}

    Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("请输入模组要安装forge的版本 示例:1.12.2");
//Console.WriteLine( Console.ReadLine() + "-forge*");
//Console.WriteLine(文本处理.搜索文件夹回传是否(当前路径 + "\\.minecraft\\versions", "1.12.2"));
#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
string 输入值 = Console.ReadLine();
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
string Forge位置 = "";
if (文本处理.搜索文件夹回传是否(当前路径 + "\\.minecraft\\versions\\", 输入值 + "-forge*"))
{
    Console.WriteLine("找到Forge还有游戏本体!");
    Forge位置 = 文本处理.搜索文件夹回传位置(当前路径 + "\\.minecraft\\versions\\", 输入值 + "-forge*");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("大哥找不到版本目录啊!是不是版本打错了???");
    Console.WriteLine("如果打错版本请从新开启本安装程序");
    Console.WriteLine("本程序将退出");
    Console.WriteLine("按任意键退出....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
}

Console.Clear();
Console.WriteLine("当前服务器-模组-版本:" + 模组信息[1]);
Console.WriteLine("当前服务器-材质-版本:" + 模组信息[5]);
Console.WriteLine("当前服务器-光影-版本:" + 模组信息[9]);

Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine("请问是否更新模组?(y/n)");
bool 更新模组 = 输入.是否默认是();
Console.WriteLine("请问是否更新材质?(y/n)");
bool 更新材质 = 输入.是否默认是();
Console.WriteLine("请问是否更新光影?(y/n)");
bool 更新光影 = 输入.是否默认是();

if (更新模组)
{
    if (文本处理.搜索文件(当前路径 + "\\data", "模组-" + 模组信息[1] + ".rar"))
    {
        Console.WriteLine("文件已存在，无需下载");
    }
    else
    {
        exe.Aria2(模组地址, 当前路径 + "\\data", "模组-" + 模组信息[1] + ".rar");
        Console.WriteLine("文件不存在，已下载该文件！");
    }
}

if (更新材质)
{
    if (文本处理.搜索文件(当前路径 + "\\data", "材质-" + 模组信息[5] + ".rar"))
    {
        Console.WriteLine("文件已存在，无需下载");
    }
    else
    {
        exe.Aria2(材质地址, 当前路径 + "\\data", "材质-" + 模组信息[5] + ".rar");
        Console.WriteLine("文件不存在，已下载该文件！");
    }
}

if (更新光影)
{
    if (文本处理.搜索文件(当前路径 + "\\data", "光影-" + 模组信息[9] + ".rar"))
    {
        Console.WriteLine("文件已存在，无需下载");
    }
    else
    {
        exe.Aria2(光影地址, 当前路径 + "\\data", "光影-" + 模组信息[9] + ".rar");
        Console.WriteLine("文件不存在，已下载该文件！");
    }
}


if (更新模组)
{
    Console.WriteLine("解压并复制模组");
    System.IO.Directory.CreateDirectory(当前路径 + "\\data\\mods");
    System.IO.Directory.Delete(当前路径 + "\\data\\mods", true);
    System.IO.Directory.CreateDirectory(Forge位置 + "\\mods");
    System.IO.Directory.Delete(Forge位置 + "\\mods", true);
    exe.WinRAR(当前路径 + "\\data\\模组-" + 模组信息[1], 当前路径 + "\\data\\" );
    System.IO.Directory.Move(当前路径 + "\\data\\mods", Forge位置+"\\mods");
}

if (更新材质)
{
    Console.WriteLine("解压并复制材质");
    System.IO.Directory.CreateDirectory(当前路径 + "\\data\\resourcepacks");
    System.IO.Directory.Delete(当前路径 + "\\data\\resourcepacks", true);
    System.IO.Directory.CreateDirectory(Forge位置 + "\\resourcepacks");
    System.IO.Directory.Delete(Forge位置 + "\\resourcepacks", true);
    exe.WinRAR(当前路径 + "\\data\\材质-" + 模组信息[5], 当前路径 + "\\data\\");
    System.IO.Directory.Move(当前路径 + "\\data\\resourcepacks", Forge位置 + "\\resourcepacks");
}

if (更新光影)
{
    Console.WriteLine("解压并复制光影");
    System.IO.Directory.CreateDirectory(当前路径 + "\\data\\shaderpacks");
    System.IO.Directory.Delete(当前路径 + "\\data\\shaderpacks", true);
    System.IO.Directory.CreateDirectory(Forge位置 + "\\shaderpacks");
    System.IO.Directory.Delete(Forge位置 + "\\shaderpacks", true);
    exe.WinRAR(当前路径 + "\\data\\光影-" + 模组信息[9], 当前路径 + "\\data\\");
    System.IO.Directory.Move(当前路径 + "\\data\\shaderpacks", Forge位置 + "\\shaderpacks");
}

Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("安装完成!");
Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("目前快易享服务器有2分支地址");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("直连节点:"+ 模组信息[17].Replace(" ", ":"));
Console.WriteLine("加速节点:"+ 模组信息[19].Replace(" ", ":"));
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("开始自动帮您测试节点延迟");

Console.WriteLine("开始测试直连节点:" + 模组信息[17].Replace(" ", ":"));
string 直连节点延迟输出 = exe.Ping2(模组信息[17]);
string[] sArray = 直连节点延迟输出.Split(new string[] { "=", "ms", "(", "fail)" }, StringSplitOptions.RemoveEmptyEntries);
string 直连节点平均延迟 = "";
string 直连节点丢包率 = "";
float 直连节点平均延迟比 = -1;
if (sArray.Length == 11)
{
    //直连节点平均延迟 = sArray[10];
    直连节点平均延迟 = "无法连接，无法提供行程统计 -1";
    直连节点丢包率 = sArray[9];
}
else
{
    直连节点平均延迟 = sArray[15];
    直连节点丢包率 = sArray[9];
    直连节点平均延迟比 = float.Parse(直连节点平均延迟);
}
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("直连节点延迟:" + 直连节点平均延迟 + "ms");
Console.WriteLine("直连节点丢包:" + 直连节点丢包率);
Console.ForegroundColor = ConsoleColor.Green;


Console.WriteLine("开始测试加速节点:" + 模组信息[19].Replace(" ", ":"));
string 加速节点延迟输出 = exe.Ping2(模组信息[19]);
sArray = 加速节点延迟输出.Split(new string[] { "=", "ms", "(", "fail)" }, StringSplitOptions.RemoveEmptyEntries);
string 加速节点平均延迟 = "";
string 加速节点丢包率 = "";
float 加速节点平均延迟比 = -1;
if (sArray.Length == 11)
{
    //直连节点平均延迟 = sArray[10];
    加速节点平均延迟 = "无法连接，无法提供行程统计 -1";
    加速节点丢包率 = sArray[9];
}
else
{
    加速节点平均延迟 = sArray[15];
    加速节点丢包率 = sArray[9];
    加速节点平均延迟比 = float.Parse(加速节点平均延迟);
}
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("加速节点延迟:" + 加速节点平均延迟 + "ms");
Console.WriteLine("加速节点丢包:" + 加速节点丢包率);
Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("测试完成!");
if (加速节点平均延迟比 > 直连节点平均延迟比)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    模组信息[17] = 模组信息[17].Replace(" ", ":");
    Console.WriteLine("推荐使用直连节点:"+ 模组信息[17].Replace(" ", ":"));
    Console.WriteLine("节点平均延迟:" + 直连节点平均延迟 + "ms");

}
else if (加速节点平均延迟比 < 直连节点平均延迟比)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("推荐使用加速节点:" + 模组信息[19].Replace(" ", ":"));
    Console.WriteLine("节点平均延迟:" + 加速节点平均延迟 + "ms");
}
else if (加速节点平均延迟比 == 直连节点平均延迟比)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("服务器可能出现故障请联系管理员");
    Console.WriteLine("@ck呵呵,QQ:2407896713");
}


Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("快易享主站 https://445720.xyz");
Console.WriteLine("快易享网盘 https://cloud.445720.xyz 提供下载服务");
Console.WriteLine("快易享MC   https://mc.445720.xyz    提供游戏服务器");
Console.WriteLine("本工具由@ck小捷所编写,欢迎交流使用");
Console.WriteLine("QQ:2407896713 @ck呵呵");
Console.WriteLine("按任意键退出,感谢您的安装与支持!!!");

Console.ReadKey(true);

//exe.WinRAR(当前路径+"\\1.rar", 当前路径);
//exe.Aria2("ftp://mc.445720.xyz/conf/conf.bat", 当前路径+"\\tool");
//exe.Aria2("https://cloud.445720.xyz/api/v3/file/source/201/%E5%85%89%E5%BD%B1-1.rar?sign=sZhnjH_2EF4d4yZYwx9rcWDKGmdKg_xEq7P0HMA8g0Q%3D%3A0", 当前路径 + "\\tool","132.bat");
//exe.CmdDw("ftp://mc.445720.xyz/conf/conf.bat", 当前路径+"\\tool","123.bat");
//exe.Ping("445720.xyz");

