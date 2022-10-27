using MC自动安装更新脚本服务器端.Json;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static MC自动安装更新脚本服务器端.MODS.MYSQ控制;
using static MC自动安装更新脚本服务器端.MODS.Json处理;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace MC自动安装更新脚本服务器端.Controllers
{
    [Route("api/获取服务器大纲")]
    [ApiController]
    public class API服务器大纲 : ControllerBase
    {
        //----------------(SQl资料)----------------
        public static MYSQL服务器 MYSQL服务器;
        public static void MYSQL服务器传入(MYSQL服务器 MYSQL服务器入)
        {
             MYSQL服务器 =  MYSQL服务器入;
        }
        //----------------(SQl资料)----------------

        [HttpGet(Name = "获取服务器大纲")]
        public IEnumerable<服务器大纲Json.Server>  Get()
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
                            //Console.WriteLine("已经建立连接");
                            //在这里使用代码对数据库进行增删查改
                string sql = "select * from 服务器大纲";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                List<服务器大纲Json.Server> 服务器大纲列表 =new List<服务器大纲Json.Server>();
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader["ID"] + " " + reader["服务器版本"] + " " + reader["服务器类型"] + " " + reader["服务器状态"] + " " + reader["服务器地址"]);//"userid"是数据库对应的列名，推荐这种方式
                    服务器大纲Json.Server 服务器大纲 = new 服务器大纲Json.Server
                    {
                        ID = (int)reader["ID"],
                        服务器版本 = (string)reader["服务器版本"],
                        服务器类型 = (string)reader["服务器类型"],
                        服务器状态 = (string)reader["服务器状态"],
                        服务器地址 = new List<string>(单层对象数组解析((string)reader["服务器地址"], "服务器地址")),
                        服务器整合 = new 服务器大纲Json.服务器整合
                        {
                            模组 = new 服务器大纲Json.模组 
                            { 
                                ID = int.Parse(单层对象解析(单层对象解析(单层对象解析((string)reader["服务器整合"], "服务器整合"), "模组"),"ID")), 
                                模组包名 = 单层对象解析(单层对象解析(单层对象解析((string)reader["服务器整合"], "服务器整合"), "模组"), "模组包名")
                            },
                            光影 = new 服务器大纲Json.光影 
                            { 
                                ID = int.Parse(单层对象解析(单层对象解析(单层对象解析((string)reader["服务器整合"], "服务器整合"), "光影"), "ID")), 
                                光影包名 = 单层对象解析(单层对象解析(单层对象解析((string)reader["服务器整合"], "服务器整合"), "光影"), "光影包名")
                            },
                            材质 = new 服务器大纲Json.材质 
                            { 
                                ID = int.Parse(单层对象解析(单层对象解析(单层对象解析((string)reader["服务器整合"], "服务器整合"), "材质"), "ID")), 
                                材质包名 = 单层对象解析(单层对象解析(单层对象解析((string)reader["服务器整合"], "服务器整合"), "材质"), "材质包名")
                            }
                        }
                        //{ 模组 = { ID = 0, 模组包名 = "" },光影 = { ID = 0, 光影包名 = "" }, 材质 = { ID = 0, 材质包名 = "" } }
                    };
                    服务器大纲列表.Add (服务器大纲);
                    //Console.WriteLine(单层对象解析(单层对象解析((string)reader["服务器整合"], "服务器整合"), "模组"));
                    //JsonConvert.SerializeObject(服务器大纲);
                    //return 服务器大纲;
                    //Console.WriteLine(      ((((JObject)JsonConvert.DeserializeObject((string)reader["服务器整合"]))["服务器整合"])["模组"])["ID"]     );
                    /*{"ID":"1","服务器版本":"1.12.2","服务器类型":"模组","服务器状态":"启用","服务器地址":["mc.445720.xyz","10.10.10.8"]} 转换Json格式*/
                }
                Console.WriteLine("["+DateTime.Now.ToString("hh:mm:ss")+"]"+ "来自于API 获取服务器大纲的GET请求");
                return 服务器大纲列表;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                return new List<服务器大纲Json.Server> { };
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }
    }
}
