using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC服务器安装
{
    internal class 键盘输入
    {
        public static bool 是否默认是()
        {
            string Yesorno = Console.ReadLine();
            if (Yesorno == "N" || Yesorno == "n")
            {
                //Console.WriteLine("否");
                return false;
            }
            else
            {
                //Console.WriteLine("是");
                return true;
            }
        }
        public static bool 是否默认否()
        {
            string Yesorno = Console.ReadLine();
            if (Yesorno == "Y" || Yesorno == "y")
            {

                //Console.WriteLine("是");
                return true;
            }
            else
            {
                //Console.WriteLine("否");
                return false;
            }
        }
        public static bool 是否循环()
        {
            string Yesorno;
            do
            {
                //Console.WriteLine("(y/n)循环");
                Yesorno = Console.ReadLine();
            }
            while (Yesorno != "Y" && Yesorno != "y" && Yesorno != "N" && Yesorno != "n");

            if (Yesorno == "Y" || Yesorno == "y")
            {

                //Console.WriteLine("是");
                return true;
            }
            else
            {
                //Console.WriteLine("否");
                return false;
            }
        }
    }
}
