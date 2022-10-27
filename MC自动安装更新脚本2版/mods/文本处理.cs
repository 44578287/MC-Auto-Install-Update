using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC自动安装更新脚本2版.mods
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
                //Console.WriteLine(fi.Name);
                return true;
            }
            return false;
        }
        public static bool 搜索文件夹回传是否(string 目标路径, string 文件夹名)
        {
            string[] dirs = { };
            try
            {
                dirs = Directory.GetDirectories(目标路径, 文件夹名, SearchOption.TopDirectoryOnly);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                //Console.WriteLine("错误:" + ex.Message);//报错
                return false;
            }
            //Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length);
            foreach (string dir in dirs)
            {
                //Console.WriteLine(dir);
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
        public static bool 移动文件夹下内容到别的文件夹下(string sourcePath, string destPath)
        {
            bool result = false;
            if (Directory.Exists(sourcePath))
            {
                DirectoryInfo folder = new DirectoryInfo(sourcePath);

                if (!Directory.Exists(destPath))
                {
                    //目标目录不存在则创建
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("创建目标目录失败：" + ex.Message);
                    }
                }

                #region 移动文件夹内所有文件
                //获得源文件下所有文件
                List<string> files = new List<string>(Directory.GetFiles(sourcePath));
                files.ForEach(c =>
                {
                    string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
                    //覆盖模式
                    if (File.Exists(destFile))
                    {
                        File.Delete(destFile);
                    }
                    File.Move(c, destFile);
                });
                #endregion

                #region 移动获得源文件下所有目录文件

                List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));
                folders.ForEach(c =>
                {
                    string destDir = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
                    //Directory.Move必须要在同一个根目录下移动才有效，不能在不同卷中移动。
                    //Directory.Move(c, destDir);

                    //采用递归的方法实现
                    移动文件夹下内容到别的文件夹下(c, destDir);
                });
                #endregion

                Directory.Delete(sourcePath);

                result = true;
            }
            else
            {
                result = false;
                throw new DirectoryNotFoundException("源目录不存在！");
            }
            return result;
        }
    }
}
