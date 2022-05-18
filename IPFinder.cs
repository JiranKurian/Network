using System;
using System.Net.NetworkInformation;

namespace NetworkAdmin
{
    public class IPFinder
    {
        public string GetPersonalIP()
        {
            string ip = string.Empty;

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in networkInterface.GetIPProperties().GatewayAddresses)
                    {
                        ip = d.Address.ToString();
                    }
                }
            }

            return ip;
        }
    }
}