using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC自动安装更新脚本2版.mods
{
    internal class 网络处理
    {
        public static bool SimplePing(string 目标域名)
        {
            Ping pingSender = new Ping();
            PingReply reply=null;
            try
            {
                reply = pingSender.Send(目标域名);
            }
            catch (PingException Message)
            {
                Console.ForegroundColor = ConsoleColor.Red;//设置字体颜色
                Console.WriteLine("错误:"+Message);
                Console.WriteLine("按任意键退出....");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
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

        public static bool DnsTest()//以DNS检测联网
        {
            try
            {
                System.Net.IPHostEntry ipHe =
                    System.Net.Dns.GetHostByName("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TcpSocketTest()//以TPC检测联网
        {
            try
            {
                System.Net.Sockets.TcpClient client =
                    new System.Net.Sockets.TcpClient("www.google.com", 80);
                client.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public static bool TcpSocketTest(string 目标域名)//以TPC检测联网自定域名
        {
            try
            {
                System.Net.Sockets.TcpClient client =
                    new System.Net.Sockets.TcpClient(目标域名, 80);
                client.Close();
                return true;
            }
            catch (System.Exception ex)
            {
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
        public static IP信息 获取IP信息()
        {
            string GetData = null;
            IP信息 IP信息返回;
            try
            {
                GetData = GetHttpResponse("http://ip-api.com/json/?lang=zh-CN&fields=status,country,regionName,city,district,isp,mobile,proxy,hosting,query", 1000);
            }
            catch (System.Net.WebException Message)
            {
                Console.ForegroundColor = ConsoleColor.Red;//设置字体颜色
                Console.WriteLine("错误:" + Message);
                Console.WriteLine("导致无法继续");
                Console.WriteLine("可能无法访问此域名");
                Console.WriteLine("按任意键退出....");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
            catch (System.UriFormatException Message)
            {
                Console.ForegroundColor = ConsoleColor.Red;//设置字体颜色
                Console.WriteLine("错误:" + Message);
                Console.WriteLine("导致无法继续");
                Console.WriteLine("ULR可能错误");
                Console.WriteLine("按任意键退出....");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
            finally
            {
                IP信息返回.身份 = Json处理.单层对象解析(GetData, "status");                         //身份 成功或失败
                IP信息返回.国家 = Json处理.单层对象解析(GetData, "country");                        //国家
                IP信息返回.区域名称 = Json处理.单层对象解析(GetData, "regionName");                 //区域名称 地区/州
                IP信息返回.城市 = Json处理.单层对象解析(GetData, "city");                           //城市（城市分区）
                IP信息返回.互联网运营商 = Json处理.单层对象解析(GetData, "isp");                    //互联网服务提供商名称
                IP信息返回.移动网络 = Convert.ToBoolean(Json处理.单层对象解析(GetData, "mobile"));  //移动（蜂窝）连接
                IP信息返回.使用代理 = Convert.ToBoolean(Json处理.单层对象解析(GetData, "proxy"));   //代理 代理、VPN 或 Tor 出口地址
                IP信息返回.主机 = Convert.ToBoolean(Json处理.单层对象解析(GetData, "hosting"));     //主机 托管、主机代管或数据中心
                IP信息返回.IP = Json处理.单层对象解析(GetData, "query");                            //IP
            }
            return IP信息返回;
        }
        public struct IP信息
        {
            public string 身份;
            public string 国家;
            public string 区域名称;
            public string 城市;
            public string 互联网运营商;
            public bool 移动网络;
            public bool 使用代理;
            public bool 主机;
            public string IP;
        }
    }
}
