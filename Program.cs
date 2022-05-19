using System;
using System.Net;
using System.Net.NetworkInformation;

namespace NetworkAdmin
{
    public class Admin
    {
        public static void Main(string[] args)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                string gatewayIP = IPFinder.GetGatewayIP();
                Console.WriteLine(gatewayIP);
                PingManager.PingAll(5, 10000, "somedata", gatewayIP);
            }
            else
            {
                Console.WriteLine("NetworkInterface unavailable");
            }
        }
    }
}