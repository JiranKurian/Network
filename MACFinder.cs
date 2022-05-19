using System;
using System.Diagnostics;

namespace NetworkAdmin
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
            if (output.Length >= 8)
            {
                return output[3].Substring(Math.Max(0, output[3].Length - 2)) + "-" + output[4] + "-" + output[5] + "-" + output[6] + "-" + output[7] + "-" + output[8].Substring(0, 2);
            }
            else
            {
                return "This system";
            }
        }
    }
}