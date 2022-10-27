using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC服务器安装
{
    internal class 网络处里
    {
        public static bool SimplePing(string 目标域名)
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(目标域名);

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("访问域名  : {0}", 目标域名);
                Console.WriteLine("解析IP地址: {0}", reply.Address.ToString());
                Console.WriteLine("响应时间  : {0}", reply.RoundtripTime);
                Console.WriteLine("访问的时间: {0}", reply.Options.Ttl);
                Console.WriteLine("是否碎片化: {0}", reply.Options.DontFragment);
                Console.WriteLine("缓冲区大小: {0}", reply.Buffer.Length);

                return true;
            }
            else
            {
                Console.WriteLine(reply.Status);
                return false;
            }
        }

        public static string GetHttpResponse(string url, int Timeout)//Get请求 (地址,等待响应时间)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = Timeout;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            //ReceivedData=retString;

            return retString;
        }
        public static string MyMac()
        {
            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    return BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                }
            }
            catch (Exception)
            {
            }
            return "00-00-00-00-00-00";
        }
        public static string MyMac1()
        {
            var macAddr =
                        (
                            from nic in NetworkInterface.GetAllNetworkInterfaces()
                            where nic.OperationalStatus == OperationalStatus.Up
                            select nic.GetPhysicalAddress().ToString()
                        ).FirstOrDefault();


            #pragma warning disable CS8603 // 可能返回 null 引用。
            return macAddr;
            #pragma warning restore CS8603 // 可能返回 null 引用。
        }
    }
}
