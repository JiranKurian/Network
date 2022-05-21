using System;
using System.Threading;
using System.Net.NetworkInformation;

namespace Network
{
    public static class PingManager
    {
        public static void PingAll(int attempts, int timeout, string data, string gatewayAddress)
        {
            string[] gatewayIP = gatewayAddress.Split('.');
            for (int i = int.Parse(gatewayIP[3]) + 1; i <= 255; i++)
            {
                string ip = gatewayIP[0] + "." + gatewayIP[1] + "." + gatewayIP[2] + "." + i;

                PingSpecific(ip, attempts, timeout, data);
            }
        }

        public static void PingSpecific(string ip, int attempts, int timeout, string data)
        {
            while (attempts > 0)
            {
                attempts--;
                new Thread(delegate ()
                {
                    try
                    {
                        Ping ping = new Ping();
                        ping.PingCompleted += new PingCompletedEventHandler(PingCompleted);
                        ping.SendAsync(ip, timeout, ip);
                    }
                    catch
                    {

                    }
                }).Start();
            }
        }

        private static void PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;

            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                Console.WriteLine($"IP Address: {ip} -- MAC: {MACFinder.GetMACAddress(ip)}");
            }
        }
    }
}