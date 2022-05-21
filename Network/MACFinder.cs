using System;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Network
{
    public static class MACFinder
    {
        public static string GetMACAddress(string ip)
        {
            Process process = new Process();
            process.StartInfo.FileName = "arp";
            process.StartInfo.Arguments = "-a " + ip;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string[] output = process.StandardOutput.ReadToEnd().Split('-');
            if (output.Length >= 6)
            {
                return (output[3].Substring(Math.Max(0, output[3].Length - 2)) + ":" + output[4] + ":" + output[5] + ":" + output[6] + ":" + output[7] + ":" + output[8].Substring(0, 2)).ToUpper();
            }
            else
            {
                string macAddresses = string.Empty;

                foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if ((networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.Name == "Ethernet") || (networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.Name == "Wi-Fi"))
                    {
                        int count = -1;
                        foreach (char character in networkInterface.GetPhysicalAddress().ToString())
                        {
                            count++;
                            if (count == 2)
                            {
                                count = 0;
                                macAddresses += ":";
                            }
                            macAddresses += character;
                        }
                        break;
                    }
                }
                return macAddresses;
            }
        }
    }
}