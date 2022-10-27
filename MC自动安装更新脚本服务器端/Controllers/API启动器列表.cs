using MC自动安装更新脚本服务器端.Json;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static MC自动安装更新脚本服务器端.MODS.MYSQ控制;
using static MC自动安装更新脚本服务器端.MODS.Json处理;
using System.Collections.Generic;
using System;

namespace MC自动安装更新脚本服务器端.Controllers
{
    [Route("api/获取启动器列表")]
    [ApiController]
    public class API启动器列表 : ControllerBase
    {
        //----------------(SQl资料)----------------
        public static MYSQL服务器 MYSQL服务器;
        public static void MYSQL服务器传入(MYSQL服务器 MYSQL服务器入)
        {
            MYSQL服务器 = MYSQL服务器入;
        }
        //----------------(SQl资料)----------------

        [HttpGet(Name = "获取启动器列表")]
        public IEnumerable<启动器列表Json.Starter> Get()
        {
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                            //在这里使用代码对数据库进行增删查改
                string sql = "select * from 启动器列表";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                List<启动器列表Json.Starter> 启动器列表列表 = new List<启动器列表Json.Starter>();
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    启动器列表Json.Starter 启动器列表 = new 启动器列表Json.Starter
                    {
                        ID = (int)reader["ID"],
                        启动器名称 = (string)reader["启动器名称"],
                        启动器下载地址 = new List<string>(单层对象数组解析((string)reader["启动器下载地址"], "启动器下载地址")),
                        启动器官网 = (string)reader["启动器官网"]
                    };
                    启动器列表列表.Add(启动器列表);
                }
                Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss") + "]" + "来自于API 获取启动器列表的GET请求");
                return 启动器列表列表;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                return new List<启动器列表Json.Starter> { };
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }
    }
}
