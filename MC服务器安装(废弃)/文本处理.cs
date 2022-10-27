using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC服务器安装
{
    internal class 文本处理
    {
        public static string 读取(string 文本地址)
        {
            string text = System.IO.File.ReadAllText(文本地址);
            return text;
        }
        public static string[] 字串关键字分割(string 字串, string 分割符)
        {
            string[] sArray = 字串.Split(分割符);
            return sArray;
        }
        public static int 搜索字串组位置(string[] 字串组, string 搜索内容)
        {
            return Array.IndexOf(字串组, 搜索内容);
        }
        public static bool 搜索文件(string 目标路径, string 文件名)
        {
            DirectoryInfo di = new DirectoryInfo(目标路径);
            foreach (var fi in di.GetFiles(文件名))
            {
                Console.WriteLine(fi.Name);
                return true;
            }
            return false;
        }
        public static bool 搜索文件夹回传是否(string 目标路径, string 文件夹名)
        {
            string[] dirs = Directory.GetDirectories(目标路径, 文件夹名, SearchOption.TopDirectoryOnly);
            //Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                return true;
            }
            return false;
        }
        public static string 搜索文件夹回传位置(string 目标路径, string 文件夹名)
        {
            string[] dirs = Directory.GetDirectories(目标路径, 文件夹名, SearchOption.TopDirectoryOnly);
            //Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length);
            foreach (string dir in dirs)
            {
                //Console.WriteLine(dir);
                return dir;
            }
            return "";
        }
    }
}
