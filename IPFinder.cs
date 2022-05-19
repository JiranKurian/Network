using System;
using System.Net.NetworkInformation;

namespace NetworkAdmin
{
    public static class IPFinder
    {
        public static string GetGatewayIP()
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in networkInterface.GetIPProperties().GatewayAddresses)
                    {
                        return d.Address.ToString();
                    }
                }
            }

            return string.Empty;
        }
    }
}