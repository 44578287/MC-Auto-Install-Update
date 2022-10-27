using System.Net.NetworkInformation;


namespace MC自动安装更新脚本2版.mods
{
    internal class 网卡
    {
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
