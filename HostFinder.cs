using System;
using System.Net;


namespace NetworkAdmin
{
    public static class HostFinder
    {
        public static string GetHostAddress(string ip)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ip);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch
            {

            }
            return string.Empty;
        }
    }

}