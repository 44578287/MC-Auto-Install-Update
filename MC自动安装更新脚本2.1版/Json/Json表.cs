using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC自动安装更新脚本2版.Json
{
    internal class Json表
    {
        public struct 服务器大纲
        {
            public int ID;
            public string 服务器版本;
            public string 服务器类型;
            public string 服务器状态;
            public List<string> 服务器地址;
            public int    模组ID;
            public string 模组包名;
            public int    光影ID;
            public string 光影包名;
            public int    材质ID;
            public string 材质包名;
        }
        public struct 模组列表
        {
            public int ID;
            public string 适用服务器版本;
            public string 模组包名;
            public List<string> 模组内容;
            public string 打包日期;
            public string 下载地址;
        }
        public struct 光影列表
        {
            public int ID;
            public string 适用服务器版本;
            public string 光影包名;
            public List<string> 光影内容;
            public string 打包日期;
            public string 下载地址;
        }
        public struct 材质列表
        {
            public int ID;
            public string 适用服务器版本;
            public string 材质包名;
            public List<string> 材质内容;
            public string 打包日期;
            public string 下载地址;
        }
        public struct 启动器列表
        {
            public int ID;
            public string 启动器名称;
            public List<string> 启动器下载地址;
            public string 启动器官网;
        }
    }
}
