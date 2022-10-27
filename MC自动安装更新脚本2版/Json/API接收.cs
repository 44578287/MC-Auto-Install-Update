using MC自动安装更新脚本2版.mods;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC自动安装更新脚本2版.Json
{
    internal class API接收
    {
        public void 获取服务器大纲(string API请求地址)
        {
            Console.WriteLine("以下为目前服务器列表");
            string API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取服务器大纲", 1000);//向服务器发送Get请求,获得服务器大纲

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
                        模组ID = (int)((JsonData["服务器整合"])["模组"])["id"],
                        模组包名 = (string)((JsonData["服务器整合"])["模组"])["模组包名"],
                        光影ID = (int)((JsonData["服务器整合"])["光影"])["id"],
                        光影包名 = (string)((JsonData["服务器整合"])["光影"])["光影包名"],
                        材质ID = (int)((JsonData["服务器整合"])["材质"])["id"],
                        材质包名 = (string)((JsonData["服务器整合"])["材质"])["材质包名"]
                    });
                Console.WriteLine("编号:" + i + " ID:" + 服务器大纲列表[i].ID + " 服务器版本:" + 服务器大纲列表[i].服务器版本 + " 服务器类型:" + 服务器大纲列表[i].服务器类型 + " 服务器状态:" + 服务器大纲列表[i].服务器状态 + " 服务器模组包名:" + 服务器大纲列表[i].模组包名 + " 服务器光影包名:" + 服务器大纲列表[i].光影包名 + " 服务器材质包名:" + 服务器大纲列表[i].材质包名 + " 服务器地址:" + string.Join(" or ", 服务器大纲列表[i].服务器地址));
            }
        }
        public void 获取模组列表(string API请求地址)
        {
            Console.WriteLine("以下为目前模组列表");

            string API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取模组列表", 1000);//向服务器发送Get请求,获得服务器大纲

            List<Json表.模组列表> 模组列表列表 = new List<Json表.模组列表>();

            JArray jArray = (JArray)JsonConvert.DeserializeObject(API返回);

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
                Console.WriteLine("编号:" + i + " ID:" + 模组列表列表[i].ID + " 适用服务器版本:" + 模组列表列表[i].适用服务器版本 + " 模组包名:" + 模组列表列表[i].模组包名 + "\r\n模组内容:\r\n" + string.Join("\r\n", 模组列表列表[i].模组内容) + "\r\n打包日期:" + 模组列表列表[i].打包日期 + " 下载地址:" + 模组列表列表[i].下载地址);
            }
        }
        public void 获取光影列表(string API请求地址)
        {
            Console.WriteLine("以下为目前光影列表");

            string API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取光影列表", 1000);//向服务器发送Get请求,获得服务器大纲

            List<Json表.光影列表> 光影列表列表 = new List<Json表.光影列表>();

            JArray jArray = (JArray)JsonConvert.DeserializeObject(API返回);

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
                Console.WriteLine("编号:" + i + " ID:" + 光影列表列表[i].ID + " 适用服务器版本:" + 光影列表列表[i].适用服务器版本 + " 光影包名:" + 光影列表列表[i].光影包名 + "\r\n光影内容:\r\n" + string.Join("\r\n", 光影列表列表[i].光影内容) + "\r\n打包日期:" + 光影列表列表[i].打包日期 + " 下载地址:" + 光影列表列表[i].下载地址);
            }
        }
        public void 获取材质列表(string API请求地址)
        {
            Console.WriteLine("以下为目前材质列表");

            string API返回 = 网络处理.GetHttpResponse(API请求地址 + "/获取材质列表", 1000);//向服务器发送Get请求,获得服务器大纲

            List<Json表.材质列表> 材质列表列表 = new List<Json表.材质列表>();

            JArray jArray = (JArray)JsonConvert.DeserializeObject(API返回);

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
                Console.WriteLine("编号:" + i + " ID:" + 材质列表列表[i].ID + " 适用服务器版本:" + 材质列表列表[i].适用服务器版本 + " 材质包名:" + 材质列表列表[i].材质包名 + "\r\n材质内容:\r\n" + string.Join("\r\n", 材质列表列表[i].材质内容) + "\r\n打包日期:" + 材质列表列表[i].打包日期 + " 下载地址:" + 材质列表列表[i].下载地址);
            }
        }
    }
}
