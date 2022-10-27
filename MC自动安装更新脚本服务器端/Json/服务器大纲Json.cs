using System.Collections.Generic;

namespace MC自动安装更新脚本服务器端.Json
{
    public class 服务器大纲Json
    {
        //{"ID":"1","服务器版本":"1.12.2","服务器类型":"模组","服务器状态":"启用","服务器地址":["mc.445720.xyz","10.10.10.8"]}Json格式
        /*public class Server
        {
            /// <summary>
            /// 
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string 服务器版本 { get; set; }
            /// <summary>
            /// 模组
            /// </summary>
            public string 服务器类型 { get; set; }
            /// <summary>
            /// 启用
            /// </summary>
            public string 服务器状态 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> 服务器地址 { get; set; }
        }*/



        //{"ID":"1","服务器版本":"1.12.2","服务器类型":"模组","服务器状态":"启用","服务器地址":["mc.445720.xyz","10.10.10.8"],"服务器整合":{"模组":{"ID":"","模组包名":""},"光影":{"ID":"","光影包名":""},"材质":{"ID":"","材质包名":""}}}Json格式
        public class 模组
        {
            /// <summary>
            /// 
            /// </summary>
            public int ? ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ? 模组包名 { get; set; }
        }

        public class 光影
        {
            /// <summary>
            /// 
            /// </summary>
            public int ? ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ? 光影包名 { get; set; }
        }

        public class 材质
        {
            /// <summary>
            /// 
            /// </summary>
            public int ? ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ? 材质包名 { get; set; }
        }

        public class 服务器整合
        {
            /// <summary>
            /// 
            /// </summary>
            public 模组 ? 模组 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public 光影 ? 光影 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public 材质 ? 材质 { get; set; }
        }

        public class Server
        {
            /// <summary>
            /// 
            /// </summary>
            public int ? ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ? 服务器版本 { get; set; }
            /// <summary>
            /// 模组
            /// </summary>
            public string ? 服务器类型 { get; set; }
            /// <summary>
            /// 启用
            /// </summary>
            public string ? 服务器状态 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> ? 服务器地址 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public 服务器整合 ? 服务器整合 { get; set; }
        }

    }
}
