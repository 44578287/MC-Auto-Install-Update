using MC自动安装更新脚本服务器端.Json;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static MC自动安装更新脚本服务器端.MODS.MYSQ控制;
using static MC自动安装更新脚本服务器端.MODS.Json处理;
using System.Collections.Generic;
using System;

namespace MC自动安装更新脚本服务器端.Controllers
{
    [Route("api/获取光影列表")]
    [ApiController]
    public class API光影列表 : ControllerBase
    {
        //----------------(SQl资料)----------------
        public static MYSQL服务器 MYSQL服务器;
        public static void MYSQL服务器传入(MYSQL服务器 MYSQL服务器入)
        {
            MYSQL服务器 = MYSQL服务器入;
        }
        //----------------(SQl资料)----------------

        [HttpGet(Name = "获取光影列表")]
        public IEnumerable<光影列表Json.LAS> Get()
        {
            //----------------(SQl资料)----------------
            /*MYSQL服务器 MYSQL服务器 = new MYSQL服务器
            {
                server = "10.10.10.7",
                port = "3306",
                user = "MC",
                password = "MC",
                database = "mc_auto_servers"
            };*/
            //----------------(SQl资料)----------------
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                            //在这里使用代码对数据库进行增删查改
                string sql = "select * from 光影列表";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                List<光影列表Json.LAS> 光影列表列表 = new List<光影列表Json.LAS>();
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    光影列表Json.LAS 光影列表 = new 光影列表Json.LAS
                    {
                        ID = (int)reader["ID"],
                        适用服务器版本 = (string)reader["适用服务器版本"],
                        光影包名 = (string)reader["光影包名"],
                        光影内容 = new List<string>(单层对象数组解析((string)reader["光影内容"], "光影内容")),
                        打包日期 = (string)reader["打包日期"],
                        下载地址 = (string)reader["下载地址"]
                    };
                    光影列表列表.Add(光影列表);
                }
                Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss") + "]" + "来自于API 获取光影列表的GET请求");
                return 光影列表列表;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                return new List<光影列表Json.LAS> { };
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }
    }
}
