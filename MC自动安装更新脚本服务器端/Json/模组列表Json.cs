using System.Collections.Generic;

namespace MC自动安装更新脚本服务器端.Json
{
    public class 模组列表Json
    {
        //{"ID":"1","适用服务器版本":"1.12.2","模组包名":"模组-10","模组内容":["模组1","模组2"],"打包日期":"2022/07/01 16:10:23","下载地址":"NULL"}//Json格式
        public class Mods
        {
            /// <summary>
            /// 
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ? 适用服务器版本 { get; set; }
            /// <summary>
            /// 模组-10
            /// </summary>
            public string ? 模组包名 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> ? 模组内容 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ? 打包日期 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ? 下载地址 { get; set; }
        }
    }
}
