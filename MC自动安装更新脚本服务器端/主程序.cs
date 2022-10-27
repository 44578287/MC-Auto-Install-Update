using static MC�Զ���װ���½ű���������.MODS.MYSQ����;
using static MC�Զ���װ���½ű���������.MODS.Json����;
using MC�Զ���װ���½ű���������.Json;
using static MC�Զ���װ���½ű���������.MODS.�����ļ���д;
using MC�Զ���װ���½ű���������.Controllers;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//------------------------------(����ȫ�ֲ���)------------------------------
string ��ǰ·�� = System.IO.Directory.GetCurrentDirectory();
string Data�ļ���·�� = ��ǰ·�� + "/Data";
string �����ļ�·�� = Data�ļ���·�� + "/Config.ini";
bool �������� = true;
MYSQL������ MYSQL������;
//------------------------------(����ȫ�ֲ���)------------------------------

//------------------------------(Ŀ¼����)------------------------------
System.IO.Directory.CreateDirectory(Data�ļ���·��);    //����Data���ϼ�
//------------------------------(Ŀ¼����)------------------------------

//------------------------------(ǰ�ù���)------------------------------
if (!�ı�����.�����ļ�(Data�ļ���·��, "Config.ini"))//���Config.ini�ļ����ж��Ƿ�Ϊ��һ������
{
    �������� = true;
    IniHelper.SetValue("��������", "��ǰ·��", ��ǰ·��, �����ļ�·��);//���浱ǰ·���������ļ���
    //-------------(MYSQL���ݿ�)-------------
    IniHelper.SetValue("MYSQL���ݿ�", "server","����д���ݿ��ַ", �����ļ�·��);
    IniHelper.SetValue("MYSQL���ݿ�", "port", "����д���ݿ�˿ں�", �����ļ�·��);
    IniHelper.SetValue("MYSQL���ݿ�", "user", "����д���ݿ��˺�", �����ļ�·��);
    IniHelper.SetValue("MYSQL���ݿ�", "password", "����д���ݿ�����", �����ļ�·��);
    IniHelper.SetValue("MYSQL���ݿ�", "database", "����д���ݿ�����", �����ļ�·��);
    //-------------(MYSQL���ݿ�)-------------

    //-------------(API����)-------------
    IniHelper.SetValue("API����", "ip", "����дAPI��IP �Ƽ���д*", �����ļ�·��);
    IniHelper.SetValue("API����", "port", "����дAPI�󶨶˿�", �����ļ�·��);
    //-------------(API����)-------------
    
    Console.WriteLine("��⵽����Ϊ��һ������,�����������ļ���ǰ��:");
    Console.WriteLine(�����ļ�·��+" (�Ѿ��Զ������)");
    Console.WriteLine("�������ļ������޸�,�޸����ٿ��������");
    System.Diagnostics.Process.Start("notepad.exe",�����ļ�·��);//�ü��±��������ļ�
    Console.WriteLine("��������˳�....");
    Console.ReadKey(true);
    System.Environment.Exit(0);
}
else
{
    �������� = false;
    if (IniHelper.GetValue("��������", "��ǰ·��", ��ǰ·��, �����ļ�·��) == ��ǰ·��)//�ж��ļ����Ƿ��ƶ���
    {
        //Console.WriteLine("û�б��ƶ���");
    }

    //-------------(��ȡ�����ļ�)-------------
    MYSQL������ = new MYSQL������
    {
        server = IniHelper.GetValue("MYSQL���ݿ�", "server", "", �����ļ�·��),
        port = IniHelper.GetValue("MYSQL���ݿ�", "port", "", �����ļ�·��),
        user = IniHelper.GetValue("MYSQL���ݿ�", "user", "", �����ļ�·��),
        password = IniHelper.GetValue("MYSQL���ݿ�", "password", "", �����ļ�·��),
        database = IniHelper.GetValue("MYSQL���ݿ�", "database", "", �����ļ�·��)
    };
    //Console.WriteLine(MYSQL������.connetStr());
    //-------------(��ȡ�����ļ�)-------------

    //-------------(MYSQL������֤)-------------
    if (!�������ݿ�(MYSQL������))//�����Ƿ���������MySql
    {
        Console.WriteLine("�����޷��������ݿ�!���������ļ������ݿ�����!");
        Console.WriteLine("��������˳�....");
        Console.ReadKey(true);
        System.Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("�������ݿ�ɹ�!");
    }
    //-------------(MYSQL������֤)-------------

    //-------------(MYSQL���ô���)-------------
    API���������.MYSQL����������(MYSQL������);
    APIģ���б�.MYSQL����������(MYSQL������);
    API��Ӱ�б�.MYSQL����������(MYSQL������);
    API�����б�.MYSQL����������(MYSQL������);
    API�������б�.MYSQL����������(MYSQL������);
    //-------------(MYSQL���ô���)-------------

    //-------------(API������֤)-------------
    if ("����дAPI��IP �Ƽ���д*".Equals(IniHelper.GetValue("API����", "ip", "", �����ļ�·��)) == true)
    {
        Console.WriteLine("API IP���ó��ִ���������ΪĬ��*");
        IniHelper.SetValue("API����", "ip", "*", �����ļ�·��);
    }
    if ("����дAPI�󶨶˿�".Equals(IniHelper.GetValue("API����", "port", "", �����ļ�·��)) == true)
    {
        Console.WriteLine("API �˿����ó��ִ���������ΪĬ��:5000");
        IniHelper.SetValue("API����", "port", "5000", �����ļ�·��);
    }
    Console.WriteLine("API����:" + "http://" + IniHelper.GetValue("API����", "ip", "", �����ļ�·��) + ":" + IniHelper.GetValue("API����", "port", "", �����ļ�·��) + "/swagger/index.html");
    //-------------(API������֤)-------------
}
//------------------------------(ǰ�ù���)------------------------------


//------------------------------(Web API������)------------------------------
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

app.Run("http://"+ IniHelper.GetValue("API����", "ip","", �����ļ�·��) + ":"+ IniHelper.GetValue("API����", "port", "", �����ļ�·��));
//------------------------------(Web API������)------------------------------



