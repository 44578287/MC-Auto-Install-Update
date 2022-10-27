using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MC自动安装更新脚本服务器端.MODS
{
    internal class Json处理
    {
        public static JObject ? JsonData;
        public static string 单层对象解析(string retString/*Json内容*/, string Value/*值名*/)
        {
            JsonData = JsonConvert.DeserializeObject(retString) as JObject;
            return JsonData[Value].ToString();
        }
        public static string 多层嵌套对象解析(string retString/*Json内容*/, string Object/*对象名*/, string Value/*值名*/)
        {
            JsonData = JsonConvert.DeserializeObject(retString) as JObject;
            return JsonData[Object][Value].ToString();
        }

        public static string[] 单层数组解析(string retString/*Json内容*/, string Value/*值名*/)//遍历
        {
            JArray ? jArray = JsonConvert.DeserializeObject(retString) as JArray;

            string[] ArrayData = new string[jArray.Count];

            for (int i = 0; i < jArray.Count; i++)
            {
                JObject JsonData = JObject.Parse(jArray[i].ToString());
                ArrayData[i] = JsonData[Value].ToString();
            }
            return ArrayData;
        }

        public static string[] 单层对象数组解析(string retString/*Json内容*/, string Object/*对象名*/)
        {
            string sites = 单层对象解析(retString, Object);
            JArray ? jArray = JsonConvert.DeserializeObject(sites) as JArray;

            string[] ArrayData = new string[jArray.Count];

            for (int i = 0; i < jArray.Count; i++)
            {
                ArrayData[i] = jArray[i].ToString();
            }
            return ArrayData;
        }
    }
}
