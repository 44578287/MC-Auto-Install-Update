using System.Collections.Generic;

namespace MC自动安装更新脚本服务器端.Json
{
    public class 材质列表Json
    {
        //{"ID":"1","适用服务器版本":"1.12.2","材质包名":"材质-10","材质内容":["材质1","材质2"],"打包日期":"2022/07/01 16:10:23","下载地址":"NULL"}//Json格式
        public class Material //Material 材质
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
            /// 材质-10
            /// </summary>
            public string ? 材质包名 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> ? 材质内容 { get; set; }
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
