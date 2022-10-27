using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC服务器安装
{
    internal class Json处理
    {
        public static JObject JsonData;
        public static string 单层对象解析(string retString/*Json内容*/, string Value/*值名*/)
        {
            JsonData = (JObject)JsonConvert.DeserializeObject(retString);
            return JsonData[Value].ToString();
        }
        public static string 多层嵌套对象解析(string retString/*Json内容*/, string Object/*对象名*/, string Value/*值名*/)
        {
            JsonData = (JObject)JsonConvert.DeserializeObject(retString);
            return JsonData[Object][Value].ToString();
        }

        public static string[] 单层数组解析(string retString/*Json内容*/, string Value/*值名*/)//遍历
        {
            JArray jArray = (JArray)JsonConvert.DeserializeObject(retString);

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
            JArray jArray = (JArray)JsonConvert.DeserializeObject(sites);

            string[] ArrayData = new string[jArray.Count];

            for (int i = 0; i < jArray.Count; i++)
            {
                ArrayData[i] = jArray[i].ToString();
            }
            return ArrayData;
        }
    }
}
