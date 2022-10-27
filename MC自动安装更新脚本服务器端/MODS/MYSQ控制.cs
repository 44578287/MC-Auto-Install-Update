using MySql.Data.MySqlClient;
using System;

namespace MC自动安装更新脚本服务器端.MODS
{
    public class MYSQ控制
    {
        public struct MYSQL服务器
        {
            public string server;  //服务器地址
            public string port;    //服务器端口
            public string user;    //帐号
            public string password;//密码
            public string database;//数据库名
            public String connetStr()
            {
                return "server=" + server + ";" + "port=" + port + ";" + "user=" + user + ";" + "password=" + password + ";" + "database=" + database + ";";
            }
        }
        public static bool 连接数据库(MYSQL服务器 MYSQL服务器)
        {
            MySqlConnection conn=null;
            try
            {
                conn = new MySqlConnection(MYSQL服务器.connetStr());
            }
            catch(System.ArgumentException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                Console.WriteLine("你鸭是不是没有去改配置文件?有的话去检查有没有写对吧!");
                Console.WriteLine("按任意键退出....");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
            catch (System.TypeAccessException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                Console.ReadKey(true);
            }

            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                //Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                return true;
            }
            catch (System.TimeoutException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                return false;
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }
        /*public static void 数据库遍历查询(MYSQL服务器 MYSQL服务器)
        {
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                string sql = "select * from user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    Console.WriteLine(reader["ID"] + " " + reader["ADM"] + " " + reader["PW"]);//"userid"是数据库对应的列名，推荐这种方式
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
            }
            finally
            {
                conn.Close();//关闭连接
            }
        }
        public static bool 数据库查询(MYSQL服务器 MYSQL服务器)
        {
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                string ADM = "root", PW = "144578287";
                //string sql = "select * from user where username='"+username+"' and password='"+password+"'"; //我们自己按照查询条件去组拼
                string sql = "select * from user where ADM=@para1 and PW=@para2";//在sql语句中定义parameter，然后再给parameter赋值
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("para1", ADM);
                cmd.Parameters.AddWithValue("para2", PW);

                Console.WriteLine("查询中...");
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())//如果用户名和密码正确则能查询到一条语句，即读取下一行返回true
                {
                    Console.WriteLine("找到了");
                    return true;
                }
                else
                {
                    Console.WriteLine("没有");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                return false;
            }
            finally
            {
                conn.Close();//关闭连接
            }
            Console.WriteLine("??");
            //return true;
        }
        public static string 数据库查询并返回(MYSQL服务器 MYSQL服务器)//返回最大值
        {
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                string sql = "select count(*) from user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Object result = cmd.ExecuteScalar();//执行查询，并返回查询结果集中第一行的第一列。所有其他的列和行将被忽略。select语句无记录返回时，ExecuteScalar()返回NULL值
                if (result != null)
                {
                    int count = int.Parse(result.ToString());
                    Console.WriteLine(count);
                    return count.ToString();
                }
                else
                {
                    Console.WriteLine("null");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                return null;
            }
            finally
            {
                conn.Close();//关闭连接
            }
            Console.WriteLine("??");
            //return true;
        }
        public static void 数据库插入(MYSQL服务器 MYSQL服务器)
        {
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                string sql = "insert into user(ADM,PW,Name) values('123','31','C#添加')";
                //string sql = "delete from user where userid='9'";
                //string sql = "update user set username='啊哈',password='123' where userid='8'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//3.执行插入、删除、更改语句。执行成功返回受影响的数据的行数，返回1可做true判断。执行失败不返回任何数据，报错，下面代码都不执行
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                //return null;
            }
            finally
            {
                conn.Close();//关闭连接
            }
            Console.WriteLine("??");
            //return true;
        }
        public static void 数据库删除(MYSQL服务器 MYSQL服务器)
        {
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                //string sql = "insert into user(ADM,PW,Name) values('123','31','C#添加')";
                string sql = "delete from user where ID='4'";
                //string sql = "update user set username='啊哈',password='123' where userid='8'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//3.执行插入、删除、更改语句。执行成功返回受影响的数据的行数，返回1可做true判断。执行失败不返回任何数据，报错，下面代码都不执行
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                //return null;
            }
            finally
            {
                conn.Close();//关闭连接
            }
            Console.WriteLine("??");
            //return true;
        }
        public static void 数据库更改(MYSQL服务器 MYSQL服务器)
        {
            MySqlConnection conn = new MySqlConnection(MYSQL服务器.connetStr());
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                //string sql = "insert into user(ADM,PW,Name) values('123','31','C#添加')";
                //string sql = "delete from user where ID='4'";
                string sql = "update user set ADM='6666', Name='更改',PW='7777' where ID='6'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//3.执行插入、删除、更改语句。执行成功返回受影响的数据的行数，返回1可做true判断。执行失败不返回任何数据，报错，下面代码都不执行
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("错误:" + ex.Message);//报错
                //return null;
            }
            finally
            {
                conn.Close();//关闭连接
            }
            Console.WriteLine("??");
            //return true;
        }*/
    }
}
