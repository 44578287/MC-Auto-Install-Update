using static MC自动安装更新脚本服务器端.MODS.MYSQ控制;
using static MC自动安装更新脚本服务器端.MODS.Json处理;
using MC自动安装更新脚本服务器端.Json;
using static MC自动安装更新脚本服务器端.MODS.配置文件读写;
using MC自动安装更新脚本服务器端.Controllers;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//------------------------------(设置全局参数)------------------------------
string 当前路径 = System.IO.Directory.GetCurrentDirectory();
string Data文件夹路径 = 当前路径 + "/Data";
string 配置文件路径 = Data文件夹路径 + "/Config.ini";
bool 初次启动 = true;
MYSQL服务器 MYSQL服务器;
//------------------------------(设置全局参数)------------------------------

//------------------------------(目录生成)------------------------------
System.IO.Directory.CreateDirectory(Data文件夹路径);    //创建Data资料夹
//------------------------------(目录生成)------------------------------

//------------------------------(前置工作)------------------------------
if (!文本处理.搜索文件(Data文件夹路径, "Config.ini"))//检查Config.ini文件以判断是否为第一次启动
{
    初次启动 = true;
    IniHelper.SetValue("环境参数", "当前路径", 当前路径, 配置文件路径);//保存当前路径到配置文件中
    //-------------(MYSQL数据库)-------------
    IniHelper.SetValue("MYSQL数据库", "server","请填写数据库地址", 配置文件路径);
    IniHelper.SetValue("MYSQL数据库", "port", "请填写数据库端口号", 配置文件路径);
    IniHelper.SetValue("MYSQL数据库", "user", "请填写数据库账号", 配置文件路径);
    IniHelper.SetValue("MYSQL数据库", "password", "请填写数据库密码", 配置文件路径);
    IniHelper.SetValue("MYSQL数据库", "database", "请填写数据库名称", 配置文件路径);
    //-------------(MYSQL数据库)-------------

    //-------------(API设置)-------------
    IniHelper.SetValue("API设置", "ip", "请填写API绑定IP 推荐填写*", 配置文件路径);
    IniHelper.SetValue("API设置", "port", "请填写API绑定端口", 配置文件路径);
    //-------------(API设置)-------------
    
    Console.WriteLine("检测到本次为第一次启动,已生成配置文件请前往:");
    Console.WriteLine(配置文件路径+" (已经自动帮你打开)");
    Console.WriteLine("对配置文件进行修改,修改完再开启服务端");
    System.Diagnostics.Process.Start("notepad.exe",配置文件路径);//用记事本打开配置文件
    Console.WriteLine("按任意键退出....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
}
else
{
    初次启动 = false;
    if (IniHelper.GetValue("环境参数", "当前路径", 当前路径, 配置文件路径) == 当前路径)//判断文件夹是否被移动过
    {
        //Console.WriteLine("没有被移动过");
    }

    //-------------(读取配置文件)-------------
    MYSQL服务器 = new MYSQL服务器
    {
        server = IniHelper.GetValue("MYSQL数据库", "server", "", 配置文件路径),
        port = IniHelper.GetValue("MYSQL数据库", "port", "", 配置文件路径),
        user = IniHelper.GetValue("MYSQL数据库", "user", "", 配置文件路径),
        password = IniHelper.GetValue("MYSQL数据库", "password", "", 配置文件路径),
        database = IniHelper.GetValue("MYSQL数据库", "database", "", 配置文件路径)
    };
    //Console.WriteLine(MYSQL服务器.connetStr());
    //-------------(读取配置文件)-------------

    //-------------(MYSQL配置验证)-------------
    if (!连接数据库(MYSQL服务器))//测试是否能连接上MySql
    {
        Console.WriteLine("错误无法连接数据库!请检查配置文件或数据库设置!");
        Console.WriteLine("按任意键退出....");
        Console.ReadKey(true);
        System.Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("连接数据库成功!");
    }
    //-------------(MYSQL配置验证)-------------

    //-------------(MYSQL配置传入)-------------
    API服务器大纲.MYSQL服务器传入(MYSQL服务器);
    API模组列表.MYSQL服务器传入(MYSQL服务器);
    API光影列表.MYSQL服务器传入(MYSQL服务器);
    API材质列表.MYSQL服务器传入(MYSQL服务器);
    API启动器列表.MYSQL服务器传入(MYSQL服务器);
    //-------------(MYSQL配置传入)-------------

    //-------------(API配置验证)-------------
    if ("请填写API绑定IP 推荐填写*".Equals(IniHelper.GetValue("API设置", "ip", "", 配置文件路径)) == true)
    {
        Console.WriteLine("API IP设置出现错误已设置为默认*");
        IniHelper.SetValue("API设置", "ip", "*", 配置文件路径);
    }
    if ("请填写API绑定端口".Equals(IniHelper.GetValue("API设置", "port", "", 配置文件路径)) == true)
    {
        Console.WriteLine("API 端口设置出现错误已设置为默认:5000");
        IniHelper.SetValue("API设置", "port", "5000", 配置文件路径);
    }
    Console.WriteLine("API详情:" + "http://" + IniHelper.GetValue("API设置", "ip", "", 配置文件路径) + ":" + IniHelper.GetValue("API设置", "port", "", 配置文件路径) + "/swagger/index.html");
    //-------------(API配置验证)-------------
}
//------------------------------(前置工作)------------------------------


//------------------------------(Web API主程序)------------------------------
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run("http://"+ IniHelper.GetValue("API设置", "ip","", 配置文件路径) + ":"+ IniHelper.GetValue("API设置", "port", "", 配置文件路径));
//------------------------------(Web API主程序)------------------------------



