namespace MC自动安装更新脚本2版.mods
{
    internal class 键盘输入
    {
        public static bool 是否默认是()
        {
            Console.Write("请输入y&n(默认y):");
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
            Console.Write("请输入y&n(默认n):");
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
                Console.Write("请输入y&n:");
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
