using System.Collections.Generic;

namespace MC自动安装更新脚本服务器端.Json
{
    public class 启动器列表Json
    {
        //{"ID":0,"启动器名称":"BakaXL_Public_Ver_3.2.1.1","启动器下载地址":["https://contents.baka.zone/Release/BakaXL_Public_Ver_3.2.1.1.exe"],"启动器官网":"https://www.bakaxl.com"}Json格式
        public class Starter//启动器
        {
            /// <summary>
            /// 
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string 启动器名称 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> 启动器下载地址 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string 启动器官网 { get; set; }
        }

    }
}
