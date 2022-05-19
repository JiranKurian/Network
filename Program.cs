using System;
using System.Net;
using System.Net.NetworkInformation;

namespace NetworkAdmin
{
    public class Admin
    {
        public static void Main(string[] args)
        {
            int dataLength = 8;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                string gatewayIP = IPFinder.GetGatewayIP();
                Console.WriteLine($"Gateway IP Adderss: {IPFinder.GetGatewayIP()}");
                PingManager.PingAll(1, 20000, RandomGenerator.GetRandomData(dataLength), gatewayIP);
            }
            else
            {
                Console.WriteLine("NetworkInterface unavailable");
            }

            Console.ReadKey();
        }
    }
}