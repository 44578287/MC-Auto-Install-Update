using MC服务器安装;
using System.Diagnostics;
using static MC服务器安装.配置文件读写;


string 当前路径 = System.IO.Directory.GetCurrentDirectory();//储存当前路径

string 年月日 = DateTime.Now.ToLongDateString().ToString();
string 时分秒 = DateTime.Now.ToString("hh时mm分ss秒");
string 电脑名称 = Environment.MachineName;

System.IO.Directory.CreateDirectory(当前路径 + "/Data");     //创建Data资料夹
System.IO.Directory.CreateDirectory(当前路径 + "/Data/Tool");//创建Tool资料夹
System.IO.Directory.CreateDirectory(当前路径 + "/Data/Log"); //创建Log资料夹

using (var cc = new Log.ConsoleCopy(当前路径+"/Data/Log/"+ 电脑名称+"-"+ 年月日+"-"+ 时分秒+".txt"))
{
    Console.Title = "快易享MC服务器自动化";//设置窗口标题

    Console.WriteLine("测试 MC服务器安装管理自动化项目");
    Console.WriteLine("本项目基于岩浆基金会所开发的服务端,请知晓!");

    Console.WriteLine("检测服务器中....");

    if (!网络处里.SimplePing("445720.xyz"))//如果连不上服务器就不继续
    {
        Console.WriteLine("服务器看来没有在工作呢,请稍后再试八");
        Console.ReadKey(true);
    }


    Console.WriteLine("检测工具.....");

    Console.WriteLine("检测aria2.exe");
    string exename = "aria2.exe";
    if (File.Exists(当前路径 + "/Data/Tool/" + exename))
    {
        Console.WriteLine("文件已存在，无需下载");
    }
    else
    {
        exe.CmdDw("https://cloud.445720.xyz/api/v3/file/source/205/aria2.exe?sign=qYUvP1eWFGCNfvTjw6Uogw9jMDLMI1NctJBiPoDx_zM%3D%3A0", 当前路径 + "/Data/Tool", exename);
        Console.WriteLine("文件不存在，已下载该文件！");
    }


    System.IO.Directory.CreateDirectory(当前路径 + "/MC_Server");//创建MC_Server资料夹,用于存放服务器资料

    string 岩浆基金会API = "https://api.magmafoundation.org";//岩浆基金会API

    Console.WriteLine("请输入您想搭建的版本 例:1.12.2");
    Console.WriteLine("版本详情请上岩浆基金会官网");
    Console.WriteLine("https://magmafoundation.org/");

    string 服务器版本 = Console.ReadLine();
    IniHelper.SetValue("服务器配置", "服务器版本", 服务器版本, 当前路径 + "/Data/config.ini");//保存至配置文件中
    System.IO.Directory.CreateDirectory(当前路径 + "/MC_Server/" + 服务器版本);//创建版本资料夹

    Console.WriteLine("下载最新版" + 服务器版本 + "服务器启动器中...");
    IniHelper.SetValue("服务器配置", "启动器下载时间", 年月日 + 时分秒, 当前路径 + "/Data/config.ini");//保存至配置文件中
    exe.Aria2(岩浆基金会API + "/api/v2/" + 服务器版本 + "/latest/download", 当前路径 + "/MC_Server/" + 服务器版本, "Magma-" + 服务器版本 + "-MC_Server.jar");//发送GET请求下载最新版启动器

    Console.WriteLine("服务器启动中...");

    string bat = "cd %~dp0 \r\nJAVA -jar " + "Magma-" + 服务器版本 + "-MC_Server.jar\r\n";
    //string bat = "ping 10.10.10.1";
    //string bat = "%~dp0";
    File.WriteAllText(当前路径 + "/MC_Server/" + 服务器版本 + "/STEA.bat", bat);
    Process.Start(当前路径 + "/MC_Server/" + 服务器版本 + "/STEA.bat");

    Console.ReadKey(true);
}